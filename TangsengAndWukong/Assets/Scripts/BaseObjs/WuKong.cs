using UnityEngine.UI;

public class WuKong : BasePlayer
{
    private StateMachine<WuKong> _stateMachine;

    private int runTime;

    public float HP;
    
    

//    public Text debugText;
    
    public void Start()
    {
        runTime = 0;
        
        _stateMachine = new StateMachine<WuKong>(this);
        _stateMachine.SetCurrentState(StayWukongState.Instance);
        
        // 设置初始状态
//        _stateMachine.SetGlobalState(GlobalShiFuState.Instance);
//        _stateMachine.SetCurrentState(StayTangSengState.Instance);
    }

    public void Update()
    {
        runTime++;
        if (runTime >= 100)
        {
            runTime = 0;
            _stateMachine.Update();
        }
    }
    
    /**
     * 展示所有状态，用于调试
     */
//    public override void showAllState()
//    {
//        string logs = "状态输出\n";
//        
//        debugText.text = logs;
//    }
}