using UnityEngine;

public class SmokeFiringState : State<Cigarette> {
    private static SmokeFiringState instance;

    public static SmokeFiringState Instance {
        get { return instance ?? (instance = new SmokeFiringState()); }
    }

    private float reduceCount = 1f;

    public int pipeLess = 0; // 烟管最小值

    private float reduceMax = 400;

    public override void Enter(Cigarette obj) {
        obj.controlSmokeParticle(true);
        // 更新烟管长度
        obj.pipeL--;
        // 添加烟火
        obj.fireL = 1;
    }

    public override void Execute(Cigarette obj) {
        updateSmokingCigarette(obj);

        if (obj.isLighting) {
            obj.controlSmokeParticle(true);
        }
        else {
            // 更换为等待状态
            obj._stateMachine.ChangeState(SmokeStayState.Instance);
        }
    }

    public override void Exit(Cigarette obj) {
        // 抽完烟 自动掉落
        obj.setTargetPosition(obj.transform.localPosition, new Vector3(obj.transform.localPosition.x, -0.5f, 0), 1.8f);
    }

    private void updateSmokingCigarette(Cigarette obj) {
        // 更新烟的最新值
        reduceCount++;
        if (reduceCount >= reduceMax / obj.reduceSpeed) {
            if (obj.pipeL > pipeLess) {
                reduceCount = 0;
                // 更新烟管长度
                obj.pipeL--;
                // 更新烟灰长度
                if (obj.sootL < 2) {
                    obj.sootL++;
                }

                // 更新粒子效果位置
                obj.UpdateParticlePosition();

                // 更新拥有者的烟瘾
                obj.reduceTobaccoAddiction(0f);
            }
            else {
                obj.fireL = 0;
                obj.controlSmokeParticle(false);
            }
        }

        obj.updateCigaretee(obj._spriteRenderer.sprite.texture);
    }
}