using UnityEngine;

public class StayTangSengState : State<ShiFu>
{
    // 单例模式
    private static StayTangSengState instance;
    public static StayTangSengState Instance
    {
        get {return instance ?? (instance = new StayTangSengState());}
    }

    public override void Enter(ShiFu obj)
    {
    }

    public override void Execute(ShiFu obj)
    {
        if (obj.tobaccoLevel != TobaccoAddictionLevel.STAY)
        {
            obj.changeState(WantSmokeTangSengState.Instance);
        }
    }

    public override void Exit(ShiFu obj)
    {
    }
}
