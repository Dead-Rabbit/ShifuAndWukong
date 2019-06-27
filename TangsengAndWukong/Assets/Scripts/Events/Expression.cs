using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expression : MonoBehaviour
{
    public Eye leftEye;
    public Eye rightEye;

    // 看向悟空
    public void lookAtWukong()
    {
        leftEye.moveTo(0.01f, 8f);
        rightEye.moveTo(0.01f, 8f);
    }
}
