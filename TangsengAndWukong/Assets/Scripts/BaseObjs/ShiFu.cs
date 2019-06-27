using UnityEngine;
using UnityEngine.UI;

public class ShiFu : BasePlayer
{
    private StateMachine<ShiFu> _stateMachine;

    private int runTime;

    // 日志相关
    public ShiFuLogs logs;
    // 动画相关
//    private bool isPlayingAnima = false;

    // 表情
    public Expression expression;

    // 存储烟的预设
    public GameObject cigarettePerfab;
    [HideInInspector]
    public GameObject cigarette;

    [HideInInspector] public float tobaccoAddiction = 0f; // 烟瘾
    private float tobaccoAddictionThresholdLookAt; // 瞪悟空的阈值
    private float maxTobaccoAddiction = 100f; // max
    [HideInInspector] public TobaccoAddictionLevel tobaccoLevel;
    [HideInInspector] public TobaccoAddictionLevel preLevel; // 前置状态

    public void Start()
    {
        runTime = 0;

        // 初始化数值
        tobaccoAddiction = 0f;
        maxTobaccoAddiction = 100f;
        tobaccoAddictionThresholdLookAt = maxTobaccoAddiction * (float) 0.3; // 初始化人物阈值
        tobaccoLevel = TobaccoAddictionLevel.STAY;

        _stateMachine = new StateMachine<ShiFu>(this);

        // 设置初始状态
        _stateMachine.SetGlobalState(GlobalShiFuState.Instance);
        _stateMachine.SetCurrentState(StayTangSengState.Instance);

        // 初始化调试工具
        initDebugTools();
    }

    public void Update()
    {
        runTime++;
        if (runTime >= 20)
        {
            runTime = 0;

            // 更新烟瘾
            updateTobaccoLevel();

            _stateMachine.Update();

            // 更新调试工具
            updateDebugTools();
        }
    }

    /**
     * 更改人物状态
     */
    public bool changeState(State<ShiFu> currentState)
    {
        _stateMachine.ChangeState(currentState);
        return true;
    }

    /**
     * 更新leve 这个可以放在state中，后面会优化
     */
    public void updateTobaccoLevel()
    {
        // 测试输出
        if (tobaccoAddiction < maxTobaccoAddiction * 0.1)
        {
            tobaccoLevel = TobaccoAddictionLevel.STAY;
        }
        else if (tobaccoAddiction < maxTobaccoAddiction * 0.2)
        {
            tobaccoLevel = TobaccoAddictionLevel.LOOK_AT;
        }
        else if (tobaccoAddiction < maxTobaccoAddiction * 0.4)
        {
            tobaccoLevel = TobaccoAddictionLevel.SHOOT;
        }
        else if (tobaccoAddiction < maxTobaccoAddiction * 0.8)
        {
            tobaccoLevel = TobaccoAddictionLevel.STRIKE;
        }
    }

    /**
     * 播放动画
     */
    public void playAnimator(string animName)
    {
        switch (animName)
        {
            case "bazhang":
                GameObject.Find("shanbazhang").GetComponent<Renderer>().enabled = true;
                GameObject.Find("shanbazhang").GetComponent<Animator>().SetBool("HiteWukong", true);
                break;
        }
    }

    /**
     * 检查当前是否在播放动画
     */
    public bool checkIfPlayingAnim(string animName)
    {
//        animatorInfo = anim.GetCurrentAnimatorStateInfo (0);
//        logs.addMessage("播放的内容为：" + animatorInfo.IsName("New State"));
//        
//        if (animatorInfo.normalizedTime > 1.0f && animatorInfo.IsName(animName))//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
//        {
//            return false;
//        }

        return true;
    }

    /**
     * 增加烟瘾
     */
    public void updateTobaccoAddiction(float value)
    {
        tobaccoAddiction += value;

        // 如果超过，则控制阈值
        if (tobaccoAddiction > maxTobaccoAddiction)
            tobaccoAddiction = maxTobaccoAddiction;
    }

    /********************************************调试相关**************************************************/
    // 展示所有状态，用于调试
    public override void showAllState()
    {
        string logs = "状态输出\n";
        logs += "烟瘾：" + tobaccoAddiction + "\n";
        Debug.Log(logs);
    }


    private Slider _tobaccoAddictionSlider;

    /**
     * 初始化各种调试工具
     */
    private void initDebugTools()
    {
        _tobaccoAddictionSlider = GameObject.Find("TobaccoSlider").GetComponent<Slider>();
        _tobaccoAddictionSlider.maxValue = maxTobaccoAddiction;
        _tobaccoAddictionSlider.value = tobaccoAddiction;
    }

    /**
     * 更新调试工具
     */
    private void updateDebugTools()
    {
        _tobaccoAddictionSlider.value = tobaccoAddiction;
    }

    public void debugChangeTobaccoAddition(float value)
    {
        tobaccoAddiction = value;
    }
}