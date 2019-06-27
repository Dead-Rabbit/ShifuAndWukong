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

        // 得到并判断唐僧的状态
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

    private void checkTangSeng(WuKong wukong) {
        TobaccoAddictionLevel tobaccoLevel = wukong.tangSeng.tobaccoLevel;
        switch (tobaccoLevel) {
            case TobaccoAddictionLevel.STAY:
                break;
            case TobaccoAddictionLevel.LOOK_AT:
                break;
            case TobaccoAddictionLevel.SHOOT:
                break;
            case TobaccoAddictionLevel.STRIKE:
                break;
        }
    }
}