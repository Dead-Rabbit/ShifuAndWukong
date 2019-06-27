using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Vector2 eyePosition;

    public EyeType type;

    private float startX = 0;
    private float endX;

    private bool moveAct = false;
    private float moveSpeed;

    private float startTime;


    public void Update()
    {
        if (moveAct)
        {
            float lerpValue = Mathf.Lerp(startX, endX, (Time.time - startTime) * moveSpeed);
            transform.localPosition = new Vector3(lerpValue, 0, 0);
            
            // 如果到达目标
            if (transform.localPosition.x.Equals(endX))
            {
                moveAct = false;
            }
        }
    }

    public void moveTo(float endX, float moveSpeed)
    {
        startTime = Time.time;
        this.moveSpeed = moveSpeed;
        this.endX = endX;
        
        moveAct = true;
    }
}

public enum EyeType
{
    LEFT,
    RIGHT
}