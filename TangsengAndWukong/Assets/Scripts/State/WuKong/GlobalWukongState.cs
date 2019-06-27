using Unity.Jobs;

public class GlobalWukongState : State<WuKong> {
    private static GlobalWukongState instance;

    public static GlobalWukongState Instance {
        get { return instance ?? (instance = new GlobalWukongState()); }
    }

    public override void Enter(WuKong obj) {
    }

    public override void Execute(WuKong obj) {
        // HP恢复
        recoverHP(obj);
        // 害怕值恢复
        recoverFear(obj);

        // 得到并判断唐僧的状态
        watchTangSeng(obj);
    }

    public override void Exit(WuKong obj) {
    }

    // 恢复HP
    private void recoverHP(WuKong obj) {
        obj.HP += 0.1f;

        if (obj.HP > 100f) {
            obj.HP = 100f;
        }
    }

    // 恢复HP
    private void recoverFear(WuKong obj) {
        obj.fear -= 0.1f;

        if (obj.fear < 0f) {
            obj.fear = 0;
        }
    }

    // 观察唐僧
    private void watchTangSeng(WuKong wukong) {
        TobaccoAddictionLevel tobaccoLevel = wukong.tangSeng.tobaccoLevel;
        float addValue = 0f;
        switch (tobaccoLevel) {
            case TobaccoAddictionLevel.STAY:
                // 不动
                break;
            case TobaccoAddictionLevel.LOOK_AT:
                addValue = 1f;
                break;
            case TobaccoAddictionLevel.SHOOT:
                addValue = 4f;
                break;
            case TobaccoAddictionLevel.STRIKE:
                addValue = 10f;
                break;
        }

        wukong.fear += addValue;
    }
}