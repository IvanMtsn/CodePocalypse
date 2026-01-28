using System;
using UnityEngine;

public class UpdateCaller : MonoBehaviour
{
    private static UpdateCaller instance;
    public static void AddUpdateCallback(Action updateMethod)
    {
        if (instance == null)
        {
            instance = new GameObject("[Update Caller]").AddComponent<UpdateCaller>();
        }
        instance.updateCallback += updateMethod;
    }
    public static void UnsubscribeUpdateCallback(Action updateMethod)
    {
        instance.updateCallback -= updateMethod;
    }

    private Action updateCallback;

    private void FixedUpdate()
    {
        if(updateCallback != null)
            updateCallback();
        else
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }
}