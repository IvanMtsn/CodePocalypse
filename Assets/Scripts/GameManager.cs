using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    public bool IsNodeMenuOpen = false;
    Transform _playerTransformSavepoint;
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
            if (parent == null) { continue; }
            for (int j = 0; j < _gameObjects.Count; j++)
            {
                if (_gameObjects[j].GameObjectInstance == parent.gameObject)
                {
                    _gameObjects[i].ParentIndex = j;
                    break;
                }
            }
        }
    }
    public void ResetToDefaultObjectStates()
    {
        var currentObjects = GetAllObjectsInMask();

        foreach (var obj in currentObjects)
        {
            if (!_gameObjects.Any(o => o.GameObjectInstance == obj))
            {
                Destroy(obj);
            }
        }
        foreach (var state in _gameObjects)
        {
            if (state.GameObjectInstance != null && state.WasActive)
            {
                state.GameObjectInstance.SetActive(true);
            }
        }
        foreach (var state in _gameObjects)
        {
            if (state.GameObjectInstance == null || !state.GameObjectInstance.activeSelf) continue;

            if (state.ParentIndex >= 0 && state.ParentIndex < _gameObjects.Count)
            {
                state.GameObjectInstance.transform.SetParent(_gameObjects[state.ParentIndex].GameObjectInstance.transform);
            }
            else
            {
                state.GameObjectInstance.transform.SetParent(null);
            }
        }
        foreach (var state in _gameObjects)
        {
            if (state.GameObjectInstance == null || !state.GameObjectInstance.activeSelf) continue;

            state.GameObjectInstance.transform.localPosition = state.LocalPosition;
            state.GameObjectInstance.transform.localRotation = state.LocalRotation;
            state.GameObjectInstance.transform.localScale = state.LocalScale;

            for (int i = 0; i < state.ComponentData.Count; i++)
            {
                var components = state.GameObjectInstance.GetComponents<MonoBehaviour>();
                var matchingComponent = components.FirstOrDefault(c => c.GetType().Name == state.ComponentTypes[i]);
                if (matchingComponent != null)
                {
                    JsonUtility.FromJsonOverwrite(state.ComponentData[i], matchingComponent);
                }
            }
        }
    }
    List<GameObject> GetAllObjectsInMask()
    {
        return Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(o => o.scene.IsValid() && ((1 << o.layer) & _objectMask.value) != 0).ToList();
    }
}