using System;
using UnityEngine;

public class Cigarette : MonoBehaviour {
    private BasePlayer owner;

    [HideInInspector] public SpriteRenderer _spriteRenderer;

    public int width = 16;
    public int height = 1;

    public int buttL; // 烟头长度
    public int pipeL; // 烟管长度 

    public int fireL; // 烟头着火长度
    public int sootL; // 烟灰长度

    public Color buttC = new Color(232, 153, 0);
    public Color pipeC = new Color(234, 242, 255);
    public Color fireC = new Color(245, 122, 98);
    public Color sootC = new Color(155, 155, 155);

    [HideInInspector] public Color nothingC = new Color(0, 0, 0, 0);

    [Range(1, 10)] public float reduceSpeed = 1;

    public bool isLighting;
    private GameObject smoke;

    public StateMachine<Cigarette> _stateMachine;

    /****************运动相关***********************/
    public MoveTools _moveTools;
    private bool moveAct;

    public void Start() {
        _stateMachine = new StateMachine<Cigarette>(this);
        _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        // 抽烟粒子相关
        smoke = GameObjectTools.GetTransform(transform, "smoke").gameObject;
        _moveTools = new MoveTools();

        _stateMachine.SetCurrentState(SmokeStayState.Instance);

        controlSmokeParticle(false); // 设置粒子关闭

        width = 16;
        height = 1;

        GenerateSprite();
    }

    // 初始化相关值
    public void Init(BasePlayer owner, float reduceSpeed) {
        this.owner = owner;

        this.reduceSpeed = reduceSpeed;
        isLighting = false;
    }

    // 点烟
    public void lightTheCigarette() {
        isLighting = true;
    }

    public void Update() {
        _stateMachine.Update();

        // 运动相关
        if (moveAct) {
            transform.localPosition = _moveTools.LerpMoveTo();

            // 判断是否到达目标
            if (_moveTools.checkGetIn(transform.localPosition)) {
                moveAct = false;
            }
        }
    }

    // 更新拥有者的烟瘾程度
    public void reduceTobaccoAddiction(float value) {
        ShiFu shifu = (ShiFu) owner;
        shifu.updateTobaccoAddiction(value);
    }

    // 设置目标点
    public void setTargetPosition(Vector3 currectPosition, Vector3 targetPosition, float moveSpeed) {
        moveAct = true;
        _moveTools.SetTarget(currectPosition, targetPosition, moveSpeed);
    }

    /**
     * 生成香烟
     */
    void GenerateSprite() {
        Texture2D t = new Texture2D(16, 1);
        t.filterMode = FilterMode.Point;
        updateCigaretee(t);

        t.Apply();
        Sprite pic = Sprite.Create(t, new Rect(0, 0, width, height), new Vector2(0, 0.5f));
        _spriteRenderer.sprite = pic;
        _spriteRenderer.sortingOrder = 2;
    }

    // 更新粒子效果发射位置
    public void UpdateParticlePosition() {
        float targetX = (buttL + pipeL + 0.5f) * 0.01f;
        smoke.transform.localPosition = new Vector3(targetX, smoke.transform.localPosition.y, 0);
    }

    // 粒子效果 开启/关闭
    public void controlSmokeParticle(bool ifOpen) {
        ParticleSystem.EmissionModule emission = smoke.GetComponent<ParticleSystem>().emission;

        ParticleSystem.MainModule smokeModule = smoke.GetComponent<ParticleSystem>().main;

        if (smoke != null) {
            if (ifOpen) {
                isLighting = true;
                smokeModule.startSpeed = 0.2f;
                emission.enabled = true;
                UpdateParticlePosition();
            }
            else {
                isLighting = false;
                smokeModule.startSpeed = 0f;
                emission.enabled = false;
            }
        }
    }

    // 更新香烟状态
    public void updateCigaretee(Texture2D t) {
        for (int h = 0; h < height; h++) {
            // 烟头
            for (int w = 0; w < buttL; w++) {
                t.SetPixel(w, h, buttC);
            }

            // 烟管
            for (int w = buttL; w < buttL + pipeL; w++) {
                t.SetPixel(w, h, pipeC);
            }

            // 烟火
            for (int w = buttL + pipeL; w < buttL + pipeL + fireL; w++) {
                t.SetPixel(w, h, fireC);
            }

            // 烟灰
            for (int w = buttL + pipeL + fireL; w < buttL + pipeL + fireL + sootL; w++) {
                t.SetPixel(w, h, sootC);
            }

            // 烟灰
            for (int w = buttL + pipeL + fireL + sootL; w < width; w++) {
                t.SetPixel(w, h, nothingC);
            }
        }

        t.Apply();
    }
}