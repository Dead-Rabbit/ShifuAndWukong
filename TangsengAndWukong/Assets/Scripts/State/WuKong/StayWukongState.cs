public class StayWukongState : State<WuKong>
{
    private static StayWukongState instance;

    public static StayWukongState Instance
    {
        get { return instance ?? (instance = new StayWukongState()); }
    }
    
    public override void Enter(WuKong obj)
    {
        
    }

    public override void Execute(WuKong obj)
    {
    }

    public override void Exit(WuKong obj)
    {
    }
}