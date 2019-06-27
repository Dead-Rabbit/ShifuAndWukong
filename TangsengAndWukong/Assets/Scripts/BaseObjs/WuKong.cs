using UnityEngine;
using UnityEngine.UI;

public class WuKong : BasePlayer {
    private StateMachine<WuKong> _stateMachine;

    private int runTime;

    [HideInInspector] public float HP;

    public ShiFu tangSeng;

    [HideInInspector] public float fear;


//    public Text debugText;

    public void Start() {
        runTime = 0;

        _stateMachine = new StateMachine<WuKong>(this);
        _stateMachine.SetCurrentState(StayWukongState.Instance);
        // 添加观察唐僧的状态
        _stateMachine.SetGlobalState(GlobalWukongState.Instance);

        HP = 100f;
    }

    public void Update() {
        runTime++;
        if (runTime >= 100) {
            runTime = 0;
            _stateMachine.Update();
        }
    }
}