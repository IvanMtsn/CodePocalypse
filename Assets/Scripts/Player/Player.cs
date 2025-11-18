using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask _hostileColliders;
    MeshRenderer _trackMeshRenderer;
    [SerializeField] float _scrollSpeed;
    Rigidbody _rb;
    void Start()
    {
        _trackMeshRenderer = transform.Find("tracks").GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //TestMove();
        if(_rb.linearVelocity.sqrMagnitude > 0.1)
        {
            _trackMeshRenderer.material.mainTextureOffset = new Vector2(0, Time.realtimeSinceStartup * _scrollSpeed);
        }
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
