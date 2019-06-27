using UnityEngine;

public class SmokeStayState : State<Cigarette>
{
    private static SmokeStayState instance;

    public static SmokeStayState Instance
    {
        get { return instance ?? (instance = new SmokeStayState()); }
    }
    
    public override void Enter(Cigarette obj)
    {
        obj.controlSmokeParticle(false);
    }

    public override void Execute(Cigarette obj)
    {
        if (obj.isLighting)
        {
            obj._stateMachine.ChangeState(SmokeFiringState.Instance);
        }
    }

    public override void Exit(Cigarette obj)
    {
        
    }
}