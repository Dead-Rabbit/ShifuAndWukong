using UnityEngine;

public class MoveTools
{
    
    private float startX = 0;
    private float startY = 0;
    
    private float endX;
    private float endY;
    
    private float moveSpeed;
    private float startTime;
    
    // 设定最终目标
    public void SetTarget(Vector3 currectPosition, Vector3 targetPosition, float moveSpeed)
    {
        startX = currectPosition.x;
        startY = currectPosition.y;
        endX = targetPosition.x;
        endY = targetPosition.y;

        startTime = Time.time;

        this.moveSpeed = moveSpeed;
    }
    
    // 利用插值得到移动中的正确位置
    public Vector3 LerpMoveTo()
    {
        float lerpX = Mathf.Lerp(startX, endX, (Time.time - startTime) * moveSpeed);
        float lerpY = Mathf.Lerp(startY, endY, (Time.time - startTime) * moveSpeed);
        
        return new Vector3(lerpX, lerpY, 0);
    }
    
    // 检查是否到达目标位置
    public bool checkGetIn(Vector3 position)
    {
        return position.x.Equals(endX) && position.y.Equals(endY);
    }
}