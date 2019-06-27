using UnityEngine;
using UnityEngine.UI;

public class WuKong : BasePlayer {
    private StateMachine<WuKong> _stateMachine;

    private int runTime;

    [HideInInspector] public float HP;

    public GameObject takeCigaretteHand;
    private Vector3 takeCigarettePosition = new Vector3(-0.11f, 0.22f, 0f);
    public GameObject takeFireHand;

    public ShiFu tangSeng;

    public float fear;
    [Range(0, 500)] public float fearMax;

    public void Awake() {
        runTime = 0;
        fear = 0;
        fearMax = 100;

        _stateMachine = new StateMachine<WuKong>(this);
        _stateMachine.SetCurrentState(StayWukongState.Instance);
        // 添加观察唐僧的状态
        _stateMachine.SetGlobalState(GlobalWukongState.Instance);

        HP = 100f;
        
        // 初始化拿着烟的手
        takeCigaretteHand.GetComponent<TakeCigaretteHand>().Init(this);
        takeFireHand.GetComponent<TakeFireHand>().Init(this);

        // 初始化调试工具
        initDebugTools();
    }

    public void Update() {
        runTime++;
        if (runTime >= 100) {
            runTime = 0;
            _stateMachine.Update();

            // 更新调试工具
            updateDebugTools();
        }
    }

    public void ChangeState(State<WuKong> s) {
        _stateMachine.ChangeState(s);
    }
    
    /***************************业务相关***************************/
    public void takeACigarette() {
        takeCigaretteHand.GetComponent<TakeCigaretteHand>().takeACigarette(takeCigarettePosition);
    }

    /*************************调试工具相关**************************/
    private Slider _fearSlider;

    /**
     * 初始化各种调试工具
     */
    private void initDebugTools() {
        _fearSlider = GameObject.Find("FearSlider").GetComponent<Slider>();
        _fearSlider.maxValue = fearMax;
        _fearSlider.value = fear;
    }

    /**
     * 更新调试工具
     */
    private void updateDebugTools() {
        _fearSlider.value = fear;
    }

    public void debugChangeFear(float value) {
        fear = value;
    }
}