using UnityEngine;

public class Player : MonoBehaviour
{
    /** TODO: movement to next coordinate, texture scrolling
     * Check if a coordinate point is available in front of the player (raycast w layermask, horizontal offset!!!)
     * scroll texture of tracks if player speed is above a certain value (probably if its just moving anyway?) **/

    [SerializeField] LayerMask _hostileColliders;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
    }
}
