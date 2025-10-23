using System.Threading.Tasks;
using UnityEngine;

public enum RotateDirection
{
    Left,
    Right
}

public class RotateNode : Node
{
    [SerializeField] GameObject Player;
    [SerializeField] RotateDirection selectedDir;
    [SerializeField] GameObject destinatedRotation;
    Rigidbody rb;
    public float MoveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override async Task RunNode()
    {
        //RotatePlayer();
        await Task.Yield();
    }

    public void RotatePlayer()
    {
        Vector3 targetDirection = rb.rotation.eulerAngles;
        Debug.Log(selectedDir.ToString());
        if (selectedDir == RotateDirection.Left)
        {
            Debug.Log("Execute Left");
            targetDirection += Vector3.down * 90;
        }
        if (selectedDir == RotateDirection.Right)
        {
            Debug.Log("Execute Right");
            targetDirection += Vector3.up * 90;
        }


        destinatedRotation.transform.SetParent(null);
        Player.GetComponent<PlayerMovement>().ToggleRotation();
        destinatedRotation.transform.eulerAngles = targetDirection;
        //float timer = 0f;

        //while (timer < 1)
        //{
        //    rb.MoveRotation(Quaternion.Slerp(Quaternion.identity, Quaternion.Euler(0, targetDirection.y, 0), timer));
        //    timer += Time.deltaTime * MoveSpeed;
        //}
        //rb.MoveRotation(Quaternion.Euler(0, targetDirection.y, 0));
    }
}
