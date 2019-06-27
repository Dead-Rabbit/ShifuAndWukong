using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeFireHand : MonoBehaviour {
    
    public GameObject lightPoint;

    private WuKong owner;
    
    [HideInInspector] public MoveTools _moveTools;
    private bool moveAct;

    public void Init(WuKong owner) {
        this.owner = owner;
    }
    
    void Awake() {
        _moveTools = new MoveTools();
    }

    // Update is called once per frame
    void Update() {
        
        // 运动相关
        if (moveAct) {
            transform.localPosition = _moveTools.LerpMoveTo();

            // 判断是否到达目标
            if (checkIfGetIn()) {
                moveAct = false;
            }
        }
    }
    
    // 检查是否到达目标点
    public bool checkIfGetIn() {
        return _moveTools.checkGetIn(transform.localPosition);
    }
    
    // 定向移动
    public void setTargetPositionByDistance(Vector3 distance, float moveSpeed) {
        _moveTools.SetTargetDistance(transform.localPosition,
            distance,
            moveSpeed);
        moveAct = true;
    }
    
    // 设置目标点 - 点烟
    public void setTargetPositionToLightCigarette(float moveSpeed) {
        _moveTools.SetTargetDistance(transform.localPosition,
            distanceFromCigaretteLight(),
            moveSpeed);
        moveAct = true;
    }
    
    /**
     * 计算当前位置到烟头
     */
    private Vector3 distanceFromCigaretteLight() {
        return owner.tangSeng.calcuDistanceToLightPosition(lightPoint.transform.position);
    }
}