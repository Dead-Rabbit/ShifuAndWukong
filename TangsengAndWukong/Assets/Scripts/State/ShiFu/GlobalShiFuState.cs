public class GlobalShiFuState : State<ShiFu>
{
    // 单例模式
    private static GlobalShiFuState instance;
    public static GlobalShiFuState Instance
    {
        get {return instance ?? (instance = new GlobalShiFuState());}
    }

    public override void Enter(ShiFu obj)
    {
    }

    public override void Execute(ShiFu obj)
    {
        // 烟瘾增加
        obj.updateTobaccoAddiction(0.4f);
    }

    public override void Exit(ShiFu obj)
    {
    }
}