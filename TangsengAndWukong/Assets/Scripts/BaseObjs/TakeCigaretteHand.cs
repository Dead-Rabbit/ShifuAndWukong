using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCigaretteHand : MonoBehaviour {
    public GameObject cigarettePrefab;

    private WuKong owner;

    [HideInInspector] public MoveTools _moveTools;
    private bool moveAct;

    [HideInInspector] public GameObject cigarette;

    public void Init(WuKong owner) {
        this.owner = owner;
    }

    public void Start() {
        _moveTools = new MoveTools();
    }

    public void Update() {
        // 运动相关
        if (moveAct) {
            transform.localPosition = _moveTools.LerpMoveTo();

            // 判断是否到达目标
            if (checkIfGetIn()) {
                moveAct = false;
            }
        }
    }

    // 设置目标点 - 上烟
    public void setTargetPositionToMouseSmoke(float moveSpeed) {
        _moveTools.SetTargetDistance(transform.localPosition,
            distanceFromMouth(),
            moveSpeed);
        moveAct = true;
    }

    // 定向移动
    public void setTargetPositionByDistance(Vector3 distance, float moveSpeed) {
        _moveTools.SetTargetDistance(transform.localPosition,
            distance,
            moveSpeed);
        moveAct = true;
    }

    // 检查是否到达目标点
    public bool checkIfGetIn() {
        return _moveTools.checkGetIn(transform.localPosition);
    }

    // 手中加一只香烟
    public void takeACigarette(Vector3 takePosition) {
        if (cigarette == null) {
            cigarette = Instantiate(cigarettePrefab, takePosition, transform.rotation);

            cigarette.transform.parent = transform;
            cigarette.GetComponent<SpriteRenderer>().sortingLayerName = "animation";
            cigarette.GetComponent<SpriteRenderer>().sortingOrder = 1;
            cigarette.transform.localPosition = takePosition;
        }
    }

    /**
     * 计算当前位置到目标运动位置的距离
     */
    private Vector3 distanceFromMouth() {
        return owner.tangSeng.calcuDistanceToMousePosition(cigarette.transform.position);
    }

}