using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask _hostileColliders;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //TestMove();
    }
    private void OnTriggerEnter(Collider other)
    {
       if(((1 << other.gameObject.layer) & _hostileColliders.value) != 0)
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
        Debug.Log("Player is KABLAMO");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void TestMove()
    {
        _rb.MovePosition(_rb.position - transform.up * Time.fixedDeltaTime);
    }
}
