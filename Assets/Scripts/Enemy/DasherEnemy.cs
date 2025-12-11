using UnityEngine;

public class DasherEnemy : MonoBehaviour
{
    [SerializeField] LayerMask _scanningLaserMask;
    void Start()
    {
        
    }
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100, _scanningLaserMask))
        {
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("LECKO MIO");
            }
        }
    }
}
