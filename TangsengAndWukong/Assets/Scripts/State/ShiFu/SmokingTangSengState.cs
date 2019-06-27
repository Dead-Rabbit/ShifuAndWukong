public class SmokingTangSengState : State<ShiFu>
{
    // 单例模式
    private static SmokingTangSengState instance;
    public static SmokingTangSengState Instance
    {
        get {return instance ?? (instance = new SmokingTangSengState());}
    }

    public override void Enter(ShiFu obj)
    {
    }

    public override void Execute(ShiFu obj)
    {
    }

    public override void Exit(ShiFu obj)
    {
    }
}