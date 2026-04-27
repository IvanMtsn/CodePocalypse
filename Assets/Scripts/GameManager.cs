using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public interface IResettable
{
    void ResetState();
}

public class ObjectState
{
    public GameObject GameObjectInstance;
    public Vector3 LocalPosition;
    public Quaternion LocalRotation;
    public Vector3 LocalScale;
    public int ParentIndex;
    public bool WasActive;
    public List<string> ComponentData = new List<string>();
    public List<string> ComponentTypes = new List<string>();
}

public class GameManager : MonoBehaviour
{
    [SerializeField] LayerMask _objectMask;
    List<ObjectState> _gameObjects = new List<ObjectState>();

    public static GameManager Instance;
    public bool IsCameraMoveable = true;

    Vector3 _playerPositionSavepoint;
    Quaternion _playerRotationSavepoint;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SaveObjectStates();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetToDefaultObjectStates();
        }
    }

    void SavePlayerState()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        _playerPositionSavepoint = player.transform.position;
        _playerRotationSavepoint = player.transform.rotation;
    }

    void ResetPlayerState()
    {
        GameObject.FindGameObjectWithTag("Player").transform
            .SetPositionAndRotation(_playerPositionSavepoint, _playerRotationSavepoint);
    }

    void SaveObjectStates()
    {
        _gameObjects.Clear();
        var currentObjects = GetAllObjectsInMask();

        foreach (var gameObject in currentObjects)
        {
            ObjectState state = new ObjectState();
            state.GameObjectInstance = gameObject;
            state.WasActive = gameObject.activeSelf;
            state.LocalPosition = gameObject.transform.localPosition;
            state.LocalRotation = gameObject.transform.localRotation;
            state.LocalScale = gameObject.transform.localScale;
            state.ParentIndex = -1;

            foreach (var component in gameObject.GetComponents<MonoBehaviour>())
            {
                if (component != null)
                {
                    state.ComponentData.Add(JsonUtility.ToJson(component));
                    state.ComponentTypes.Add(component.GetType().Name);
                }
            }

            _gameObjects.Add(state);
        }

        for (int i = 0; i < _gameObjects.Count; i++)
        {
            Transform parent = _gameObjects[i].GameObjectInstance.transform.parent;
            if (parent == null) continue;

            for (int j = 0; j < _gameObjects.Count; j++)
            {
                if (_gameObjects[j].GameObjectInstance == parent.gameObject)
                {
                    _gameObjects[i].ParentIndex = j;
                    break;
                }
            }
        }

        SavePlayerState();
    }

    public void ResetToDefaultObjectStates()
    {
        var currentObjects = GetAllObjectsInMask();

        // Remove new objects
        foreach (var obj in currentObjects)
        {
            if (!_gameObjects.Any(o => o.GameObjectInstance == obj))
            {
                Destroy(obj);
            }
        }

        // Restore active state properly
        foreach (var state in _gameObjects)
        {
            if (state.GameObjectInstance != null)
            {
                state.GameObjectInstance.SetActive(state.WasActive);
            }
        }

        // Stop coroutines + reset physics BEFORE restoring data
        foreach (var state in _gameObjects)
        {
            if (state.GameObjectInstance == null) continue;

            var behaviours = state.GameObjectInstance.GetComponents<MonoBehaviour>();
            foreach (var b in behaviours)
            {
                b.StopAllCoroutines();
            }

            var rb = state.GameObjectInstance.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }

        // Restore hierarchy (only important for enemies)
        foreach (var state in _gameObjects)
        {
            if (state.GameObjectInstance == null || !state.GameObjectInstance.activeSelf) continue;

            if (state.ParentIndex >= 0 && state.ParentIndex < _gameObjects.Count)
            {
                state.GameObjectInstance.transform.SetParent(
                    _gameObjects[state.ParentIndex].GameObjectInstance.transform);
            }
            else
            {
                state.GameObjectInstance.transform.SetParent(null);
            }
        }

        // Restore transform stuff + component data
        foreach (var state in _gameObjects)
        {
            if (state.GameObjectInstance == null || !state.GameObjectInstance.activeSelf) continue;

            var t = state.GameObjectInstance.transform;
            t.localPosition = state.LocalPosition;
            t.localRotation = state.LocalRotation;
            t.localScale = state.LocalScale;

            for (int i = 0; i < state.ComponentData.Count; i++)
            {
                var components = state.GameObjectInstance.GetComponents<MonoBehaviour>();
                var matchingComponent = components.FirstOrDefault(
                    c => c.GetType().Name == state.ComponentTypes[i]);

                if (matchingComponent != null)
                {
                    JsonUtility.FromJsonOverwrite(state.ComponentData[i], matchingComponent);
                }
            }
        }

        /* Call custom reset logic (VERY IMPORTANT FOR OBSTACLES AND ENEMIES!!!)
         * IResettable is needed to restore enemies and dynamic obstacles to their original value
         * example: Dashers need to reset their scanner state and thruster mesh on reset.
         * You need to define the IResettable for every enemy/dynamic obstacle that you create (duh)
         */
        foreach (var state in _gameObjects)
        {
            if (state.GameObjectInstance == null) continue;

            foreach (var resettable in state.GameObjectInstance.GetComponents<IResettable>())
            {
                resettable.ResetState();
            }
        }

        ResetPlayerState();
    }

    List<GameObject> GetAllObjectsInMask()
    {
        return Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(o => o.scene.IsValid() && ((1 << o.layer) & _objectMask.value) != 0)
            .ToList();
    }

    public void SetCameraMoveableState(bool value)
    {
        IsCameraMoveable = value;
    }

    public void CloseGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}