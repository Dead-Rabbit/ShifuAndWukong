using UnityEngine;

public class WantSmokeTangSengState : State<ShiFu>
{
    // 单例模式
    private static WantSmokeTangSengState instance;

    public static WantSmokeTangSengState Instance
    {
        get { return instance ?? (instance = new WantSmokeTangSengState()); }
    }

    public override void Enter(ShiFu obj)
    {
        obj.logs.addMessage("OS：想抽烟了");
    }

    public override void Execute(ShiFu obj)
    {
        if (obj.preLevel != obj.tobaccoLevel)
        {
            switch (obj.tobaccoLevel)
            {
                case TobaccoAddictionLevel.LOOK_AT:
                    Debug.Log("动作：瞪着悟空");
                    obj.expression.lookAtWukong();

                    // 给烟测试
                    GameObject cigrette =
                        (GameObject) GameObject.Instantiate(obj.cigarettePerfab, new Vector3(0.06f, -0.135f, 0),
                            obj.transform.rotation);
                    // 初始化值
                    cigrette.GetComponent<Cigarette>().Init(obj, 1f);
                    cigrette.transform.parent = obj.transform;
                    cigrette.transform.localPosition = new Vector3(0.06f, -0.135f, 0);
                    obj.cigarette = cigrette;

                    break;
                case TobaccoAddictionLevel.SHOOT:
                    Debug.Log("动作：喊悟空");
                    
                    // 点烟测试
                    if (obj.cigarette != null)
                        obj.cigarette.GetComponent<Cigarette>().lightTheCigarette();
                    
                    break;
                case TobaccoAddictionLevel.STRIKE:
                    Debug.Log("动作：打悟空");
                    obj.playAnimator("bazhang");
                    break;
            }

            obj.preLevel = obj.tobaccoLevel;
        }
    }

    public override void Exit(ShiFu obj)
    {
    }
}