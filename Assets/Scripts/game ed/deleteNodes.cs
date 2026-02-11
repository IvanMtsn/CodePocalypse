using UnityEngine;
using UnityEngine.EventSystems;

public class deleteNodes : MonoBehaviour
{
    [SerializeField] private GameObject nodeField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(2)) 
      {
          OnMiddleMouseClick();
          Debug.Log("Middle mouse button clicked");
      }
    }

    void OnMiddleMouseClick()
    {
        foreach (Transform child in nodeField.transform)
        {
            // if (EventSystem.current.IsPointerOver())
            // {
            //     Destroy(child.gameObject);
            // }
        }
    }
}
