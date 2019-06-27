using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiFuLogs : MonoBehaviour
{
    private Text text;

    public void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    /**
     * 追加消息
     */
    public void addMessage(string msg)
    {
        text.text = msg + "\n" + text.text;
    }
}
