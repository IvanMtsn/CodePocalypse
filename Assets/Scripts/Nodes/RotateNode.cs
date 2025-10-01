using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class RotateNode : ExecuteableNode
{
    enum Direction
    {
        Left,
        Right
    }

    [SerializeField] GameObject Player;
    [SerializeField] Direction selectedDir;
    public float MoveSpeed;
    //float highestOrLowestPoint;
    //bool useBigQ = true;
    TMP_Dropdown dropdown;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = Player.GetComponent<Rigidbody>();
        dropdown = GetComponentInChildren<TMP_Dropdown>();
        //highestOrLowestPoint = 0;
    }

    public override async Task Execute()
    {
        Vector3 targetDirection = rb.rotation.eulerAngles;
        Debug.Log(selectedDir.ToString());
        if(selectedDir == Direction.Left)
        {
            Debug.Log("Execute Left");
            targetDirection += Vector3.down * 90;
        }
        if (selectedDir == Direction.Right)
        {
            Debug.Log("Execute Right");
            targetDirection += Vector3.up * 90;
        }
        //Quaternion rotation = rb.rotation.normalized;
        //Debug.Log(Quaternion.Euler(0, 90, 0).y);
        //Debug.Log($"rb.rotation.y: {rb.rotation.y}, +90: {rb.rotation.y +90}, -90: {rb.rotation.y-90}");
        //while (Mathf.Abs(Player.transform.rotation.y) <= Mathf.Abs(rotation.y) + 0.5f)
        //while (Mathf.Asin(rb.rotation.y) * (180 / Mathf.PI) <= Mathf.Asin(rotation.y) * (180 / Mathf.PI) + 45 && Mathf.Asin(rb.rotation.y) * (180 / Mathf.PI) >= Mathf.Asin(rotation.y) * (180 / Mathf.PI) - 45)
        //{
        //    Quaternion deltaRotation = Quaternion.Euler(MoveSpeed * Time.deltaTime * targetDirection).normalized;
        //    Debug.Log(deltaRotation.ToString());
        //    Debug.Log(Mathf.Asin(rb.rotation.y) * (180/Mathf.PI) * 2);
        //    rb.MoveRotation(rb.rotation * deltaRotation);
        //    await Task.Yield();
        //}

        //Player.transform.rotation.ToAngleAxis(out float angle, out _);
        float startingAngle = rb.rotation.eulerAngles.y;
        float timer = 0f;

        while (timer < 1)
        {
            rb.MoveRotation(Quaternion.Slerp(Quaternion.Euler(0, startingAngle,0), Quaternion.Euler(0,targetDirection.y,0), timer));
            timer += Time.deltaTime/10 * MoveSpeed;
        }
        rb.MoveRotation(Quaternion.Euler(0,targetDirection.y,0));
        await Task.Yield();
        await Task.Delay(500);

        //if 
        //    (
        //        rb.rotation.normalized.y > 0.6f &&
        //        selectedDir == RotateNode.Direction.Right ||
        //        rb.rotation.normalized.y < -0.6f && 
        //        selectedDir == RotateNode.Direction.Left
        //    )
        //{
        //    useBigQ = false;
        //}
        //else
        //{
        //    useBigQ = true; 
        //}
        //Debug.Log(useBigQ);
        //while (
        //        useBigQ &&
        //        rb.rotation.normalized.y <= rotation.y + Quaternion.Euler(0,90,0).y &&
        //        rb.rotation.normalized.y >= rotation.y - Quaternion.Euler(0, 90, 0).y ||
        //        !useBigQ &&
        //        rb.rotation.normalized.y <= rotation.y + (0.999f-Quaternion.Euler(0, 90, 0).y) &&
        //        rb.rotation.normalized.y >= rotation.y - (0.999f - Quaternion.Euler(0, 90, 0).y) &&
        //        rb.rotation.normalized.y != highestOrLowestPoint
        //      )
        //{
        //    Debug.Log(rb.rotation.normalized.y);
        //    Quaternion deltaRotation = Quaternion.Euler(MoveSpeed * Time.deltaTime * targetDirection).normalized;
        //    rb.MoveRotation(rb.rotation * deltaRotation);
        //    if(highestOrLowestPoint < rb.rotation.normalized.y && highestOrLowestPoint > 0 || highestOrLowestPoint > rb.rotation.normalized.y && highestOrLowestPoint < 0) 
        //    {
        //        highestOrLowestPoint = rb.rotation.normalized.y;
        //    }
        //    await Task.Yield();
        //}
    }

    public void ChangeDirection(int value)
    {
        Debug.Log(value.ToString());
        switch (value)
        {
            case 0: selectedDir = Direction.Left; break;
            case 1: selectedDir = Direction.Right; break;
            default: selectedDir = Direction.Left; break;
        }
    }
}
