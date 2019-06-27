using UnityEngine;

public class GiveCigaretteWukongState : State<WuKong> {
    private static GiveCigaretteWukongState instance;

    public static GiveCigaretteWukongState Instance => instance ?? (instance = new GiveCigaretteWukongState());

    private bool finishedStepOne = false;

    public override void Enter(WuKong obj) {
        finishedStepOne = false;
        
        // 手指夹烟
        obj.takeACigarette();

        // 设置运动目标点
        obj.takeCigaretteHand.GetComponent<TakeCigaretteHand>().setTargetPositionToMouseSmoke(1f);
    }

    public override void Execute(WuKong obj) {
        if (obj.takeCigaretteHand.GetComponent<TakeCigaretteHand>().checkIfGetIn()) {
            if (!finishedStepOne) {
                finishedStepOne = true;
                // 如果第一次到达目标
                // 递烟行为
                obj.tangSeng.takeACigarette();
                // 销毁当前烟
                GameObject.Destroy(obj.takeCigaretteHand.GetComponent<TakeCigaretteHand>().cigarette);
                // 更换目标位置为下方
                obj.takeCigaretteHand.GetComponent<TakeCigaretteHand>()
                    .setTargetPositionByDistance(new Vector3(0.5f, -0.75f, 0), 1f);
            }
            else {
                // 完成第二步骤
                obj.ChangeState(LightCigaretteWukongState.Instance);
            }
        }
    }

    public override void Exit(WuKong obj) {
    }
}