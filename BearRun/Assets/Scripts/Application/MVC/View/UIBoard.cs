/****************************************************
    文件：UIBoard.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIBoard : View
{
    #region 字段

    public const int startTime = 50;
    int m_Coin = 0;
    int m_Distance = 0;
    float m_Time;
    int m_goalCount = 0;
    int m_SkillTime= 0;

    public Text texCoin;
    public Text texDistance;
    public Text texTimer;

    public Text texGizmoMagnet;
    public Text texGizmoMultiple;
    public Text texGizmoInvincible;

    public Slider sliTime;

    public Button btnMagnet;
    public Button btnMultiple;
    public Button btnInvincible;

    GameModel gm;
    #endregion
    #region 属性
    public override string Name
    {
        get
        {
            return Consts.V_Board;
        }
    }

    public int Coin
    {
        get
        {
            return m_Coin;
        }

        set
        {
            m_Coin = value;
            texCoin.text = value.ToString();
        }
    }

    public int Distance
    {
        get
        {
            return m_Distance;
        }

        set
        {
            m_Distance = value;
            texDistance.text = value.ToString() + "米";
        }
    }

    public float MyTime
    {
        get
        {
            return m_Time;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
                SendEvent(Consts.E_EndGame);
            }
            if (value > startTime)
            {
                value = startTime;
            }
            m_Time = value;
            texTimer.text = m_Time.ToString("f2") + "s";
            sliTime.value = value / startTime;
        }
    }

    public int GoalCount
    {
        get
        {
            return m_goalCount;
        }

        set
        {
            m_goalCount = value;
        }
    }
    #endregion

    public override void RegisterAttentionEvent()
    {
        attentionList.Add(Consts.E_UpdateDis);
        attentionList.Add(Consts.E_UpdateCoin);
        attentionList.Add(Consts.E_HitAddTime);
    }

    public override void HandleEvent(string name, object data)
    {
        switch (name)
        {
            case Consts.E_UpdateDis:
                DistanceArgs e = data as DistanceArgs;
                Distance = e.distance;
                break;
            case Consts.E_UpdateCoin:
                CoinArgs c = data as CoinArgs;
                Coin += c.coin;
                break;
            case Consts.E_HitAddTime:
                MyTime += 20;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 暂停按钮点击
    /// </summary>
    public void OnPauseClick()
    {
        PauseArgs e = new PauseArgs() { coin = Coin, distance = Distance, goal = GoalCount * 30 + Distance + Coin * 3 };
        SendEvent(Consts.E_PauseGame, e);
    }

    /// <summary>
    /// 更新三个技能的按钮 是否可用
    /// </summary>
    public void UpdateUI()
    {
        ShowOrHide(gm.m_Invincible,btnInvincible);
        ShowOrHide(gm.m_Magnet, btnMagnet);
        ShowOrHide(gm.m_Multiple, btnMultiple);
    }

    void ShowOrHide(int i,Button btn)
    {
        if (i > 0)
        {
            btn.interactable = true;
            btn.transform.Find("Mask").gameObject.SetActive(false);
        }
        else
        {
            btn.interactable = false;
            btn.transform.Find("Mask").gameObject.SetActive(true);
        }
    }

    int m_Multiply = 1;
    IEnumerator MultiplyCor;  //保持双倍金币的唯一性
    /// <summary>
    /// 双倍金币
    /// </summary>
    public void HitMultiply()
    {
        if (MultiplyCor != null)
        {
            StopCoroutine(MultiplyCor);
        }
        MultiplyCor = MultiplyCoroutine();
        StartCoroutine(MultiplyCor);
    }

    IEnumerator MultiplyCoroutine()
    {
        float timer = m_SkillTime;
        texGizmoMultiple.transform.parent.gameObject.SetActive(true);
        while (timer > 0)
        {
            if (gm.m_isPlay && !gm.m_isPause)
                timer -= Time.deltaTime;
            texGizmoMultiple.text = GetTime(timer);
            yield return 0;
        }
        texGizmoMultiple.transform.parent.gameObject.SetActive(false);
    }
    SphereCollider m_MagnetCollider;
    IEnumerator MagnetCor;
    /// <summary>
    /// 吸铁石
    /// </summary>
    public void HitMagnet()
    {
        if (MagnetCor != null)
        {
            StopCoroutine(MagnetCor);
        }
        MagnetCor = MangetCoroutine();
        StartCoroutine(MagnetCor);
    }
    IEnumerator MangetCoroutine()
    {
        float timer = m_SkillTime;
        texGizmoMagnet.transform.parent.gameObject.SetActive(true);
        while (timer > 0)
        {
            if (gm.m_isPlay && !gm.m_isPause)
                timer -= Time.deltaTime;
            texGizmoMultiple.text = GetTime(timer);
            yield return 0;
        }
        texGizmoMagnet.transform.parent.gameObject.SetActive(false);
    }

    bool m_isInvincible = false;
    IEnumerator InvincibleCor;
    /// <summary>
    /// 无敌状态
    /// </summary>
    public void HitInvincible()
    {
        if (InvincibleCor != null)
        {
            StopCoroutine(InvincibleCor);
        }
        InvincibleCor = InvincibleCoroutine();
        StartCoroutine(InvincibleCor);
    }

    IEnumerator InvincibleCoroutine()
    {
        float timer = m_SkillTime;
        texGizmoInvincible.transform.parent.gameObject.SetActive(true);
        while (timer > 0)
        {
            if (gm.m_isPlay && !gm.m_isPause)
                timer -= Time.deltaTime;
            texGizmoInvincible.text = GetTime(timer);
            yield return 0;
        }
        texGizmoInvincible.transform.parent.gameObject.SetActive(false);
    }

    string GetTime(float time)
    {
        return ((int)time +1).ToString();
    }

    /// <summary>
    /// Magnet
    /// </summary>
    public void OnMagnetClick()
    {
        ItemArgs e = new ItemArgs() { count = 1, kind = ItemKind.magnetItem };
        SendEvent(Consts.E_HitItem,e);
    }
    public void OnInvincibleClick()
    {
        ItemArgs e = new ItemArgs() { count = 1, kind = ItemKind.invincibleItem };
        SendEvent(Consts.E_HitItem, e);
    }
    public void OnMultipleClick()
    {
        ItemArgs e = new ItemArgs() { count = 1, kind = ItemKind.multipleItem };
        SendEvent(Consts.E_HitItem, e);
    }

    public void Show() { gameObject.SetActive(true); }
    public void Hide() { gameObject.SetActive(false); }


    private void Awake()
    {
        m_Time = startTime;
        gm = GetModel<GameModel>();

        m_SkillTime = (int)gm.m_SkillTime;
        UpdateUI();
    }
    private void Update()
    {
        if (!gm.m_isPause && gm.m_isPlay)
            MyTime -= Time.deltaTime;
    }

}