using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : MonoBehaviour
{
    public List<GameObject> Pages;
    private int currentPageIndex = 0;
    public int CurrentPageIndex { 
        get 
        { 
            return currentPageIndex; 
        } 
        set 
        {
            currentPageIndex = value;
            if (value < 0) 
            { 
                currentPageIndex = 0;
            }
            if (value > Pages.Count) 
            { 
                currentPageIndex = Pages.Count - 1;    
            }
        }  
    }
    //public GameObject firstPage;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Pages.Add(transform.GetChild(i).gameObject);
            Debug.Log(Pages[i].name);
        }
    }
}
