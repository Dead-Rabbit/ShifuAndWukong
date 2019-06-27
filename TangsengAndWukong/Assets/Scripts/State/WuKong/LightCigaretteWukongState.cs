using UnityEngine;

public class LightCigaretteWukongState : State<WuKong> {
    private static LightCigaretteWukongState instance;

    public static LightCigaretteWukongState Instance => instance ?? (instance = new LightCigaretteWukongState());

    private int step = 0;

    public override void Enter(WuKong obj) {
        step = 0;
        
        // 设置运动目标点
        obj.takeFireHand.GetComponent<TakeFireHand>().setTargetPositionToLightCigarette(1f);
    }

    public override void Execute(WuKong obj) {
        if (obj.takeFireHand.GetComponent<TakeFireHand>().checkIfGetIn()) {
            if (step == 0) {
                // 点烟行为
                obj.tangSeng.fireACigarette();
                // 进入第二步
                step++;
                obj.takeFireHand.GetComponent<TakeFireHand>()
                    .setTargetPositionByDistance(new Vector3(0.5f, -0.75f, 0), 1f);
            }
            else {
                // 进入下一步
                obj.ChangeState(StayWukongState.Instance);
            }
        }
    }

    public override void Exit(WuKong obj) {
    }
}