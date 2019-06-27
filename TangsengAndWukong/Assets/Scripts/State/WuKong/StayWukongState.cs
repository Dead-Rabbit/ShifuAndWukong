
using UnityEngine;

public class StayWukongState : State<WuKong> {
    private static StayWukongState instance;

    public static StayWukongState Instance {
        get { return instance ?? (instance = new StayWukongState()); }
    }

    private float toGive = 0.01f;

    public override void Enter(WuKong obj) {
    }

    public override void Execute(WuKong obj) {
        if (obj.fear > obj.fearMax * toGive) {
            obj.ChangeState(GiveCigaretteWukongState.Instance);
        }
    }

    public override void Exit(WuKong obj) {
    }
}