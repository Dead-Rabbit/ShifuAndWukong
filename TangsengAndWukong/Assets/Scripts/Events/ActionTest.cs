using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTest : MonoBehaviour
{
    public void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void testAction()
    {
        Debug.Log("悟空: HP - 1");
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
