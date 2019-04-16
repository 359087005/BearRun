/****************************************************
    文件：PlayerMove.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections;
using UnityEngine;

public class PlayerMove : View
{
    public override string Name
    {
        get
        {
            return Consts.V_PlayerMove;
        }
    }

    public override void HandleEvent(string name, object data)
    {

    }


    CharacterController m_cc;
    public float speed = 20;

    InputDir m_InputDir = InputDir.NULL;
    bool activeInput = false;
    Vector3 m_mousePos;

    int m_nowIndex = 1;     //左中右三条
    int m_targetIndex = 1;
    float m_xOffset;   //左移右移偏移量
    float m_MoveSpeed = 13;//左移右移移动速度



    float m_yOffset;
    const float gravity = 9.8f;
    const float m_JumpValue = 5;

    float m_sliderTime;
    bool m_isSlide = false;

    float m_moveCount;
    float m_moveAddDis = 200;
    float m_moveAddSpeed = 2;
    float m_MaxSpeed = 40;

    GameModel gm;

    private void Awake()
    {
        m_cc = this.GetComponent<CharacterController>();
        gm = GetModel<GameModel>();
        m_SkillTime = gm.m_SkillTime;

        //子物体 吸铁石collider
        m_MagnetCollider = GetComponentInChildren<SphereCollider>();
    }

    private void Start()
    {
        StartCoroutine(UpdateAction());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gm.m_isPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            gm.m_isPause = false;
        }
    }

    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Consts.TAG_BigFence)
        {
            if (m_isInvincible) return;
            if (m_isSlide == true) return;
            other.gameObject.SendMessage("HitPlayer", transform.position);
            //播放声音
            Game.Instance.soundManager.PlayEffect("Se_UI_Hit");
            HitObstacles();
        }
        else if (other.tag == Consts.TAG_SmallFence)
        {
            if (m_isInvincible) return;
            other.gameObject.SendMessage("HitPlayer", transform.position);
            //播放声音
            Game.Instance.soundManager.PlayEffect("Se_UI_Hit");
            HitObstacles();
        }
        else if (other.tag == Consts.TAG_Block)
        {
            other.gameObject.SendMessage("HitPlayer", transform.position);
            Game.Instance.soundManager.PlayEffect("Se_UI_End");
            //游戏结束  弹出面板  isplay = false
            SendEvent(Consts.E_EndGame);
        }
        else if (other.tag == Consts.TAG_SmallBlock)
        {
            other.transform.parent.parent.SendMessage("HitPlayer", transform.position);
            Game.Instance.soundManager.PlayEffect("Se_UI_End");
            //游戏结束  弹出面板  isplay = false
            SendEvent(Consts.E_EndGame);
        }
        else if (other.tag == Consts.TAG_BeforeTrigger)
        {
            other.transform.parent.SendMessage("HitTrigger",SendMessageOptions.RequireReceiver);
        }
    }
    //记录速度  撞到陷阱时使用
    float m_curSpeed;
    //恢复速度 的速度
    float m_AddRate = 10;
    //是否处于撞击状态
    bool m_IsHit = false;
    /// <summary>
    /// 碰撞陷阱减速
    /// </summary>
    public void HitObstacles()
    {
        if (m_IsHit)
            return;
        m_IsHit = true;
        m_curSpeed = speed;
        speed = 0;
        StartCoroutine(RecoverySpeed());
    }
    /// <summary>
    /// 速度恢复
    /// </summary>
    /// <returns></returns>
    IEnumerator RecoverySpeed()
    {
        while (speed < m_curSpeed)
        {
            speed += Time.deltaTime * m_AddRate;
            yield return 0;
        }
        m_IsHit = false;
    }

    IEnumerator UpdateAction()
    {
        while (true)
        {
            if (!gm.m_isPause && gm.m_isPlay)
            {
                //更新UI
                UpdateDis();


                m_yOffset -= gravity * Time.deltaTime;
                m_cc.Move((transform.forward * speed + new Vector3(0, m_yOffset, 0)) * Time.deltaTime);
                MoveControl();
                UpdateSpeed();
                UpdatePositon();
            }
            yield return 0;
        }
    }

    void UpdateDis()
    {
        DistanceArgs e = new DistanceArgs() { distance = (int)transform.position.z};
        SendEvent(Consts.E_UpdateDis,e);
    }
    /// <summary>
    /// 获取朝向
    /// </summary>
    void GetInputDir()
    {
        m_InputDir = InputDir.NULL;
        if (Input.GetMouseButtonDown(0))
        {
            activeInput = true;
            m_mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && activeInput)
        {
            Vector3 dir = Input.mousePosition - m_mousePos;
            if (dir.magnitude > 20)
            {
                if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y) && dir.x > 0)
                {
                    m_InputDir = InputDir.RIGHT;
                }
                else if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y) && dir.x < 0)
                {
                    m_InputDir = InputDir.LEFT;
                }
                else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y) && dir.y > 0)
                {
                    m_InputDir = InputDir.UP;
                }
                else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y) && dir.y < 0)
                {
                    m_InputDir = InputDir.DOWN;
                }
            }
            //print(m_InputDir.ToString());
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            m_InputDir = InputDir.UP;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            m_InputDir = InputDir.DOWN;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            m_InputDir = InputDir.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            m_InputDir = InputDir.RIGHT;
        }
    }

    void UpdatePositon()
    {
        GetInputDir();

        switch (m_InputDir)
        {
            case InputDir.NULL:
                break;
            case InputDir.LEFT:
                if (m_targetIndex > 0)
                {
                    m_targetIndex--;
                    m_xOffset = -2;
                    SendMessage("AnimManager", m_InputDir);
                    Game.Instance.soundManager.PlayEffect("Se_UI_Huadong");
                }
                break;
            case InputDir.RIGHT:
                if (m_targetIndex < 2)
                {
                    m_targetIndex++;
                    m_xOffset = 2;
                    SendMessage("AnimManager", m_InputDir);
                    Game.Instance.soundManager.PlayEffect("Se_UI_Huadong");
                }
                break;
            case InputDir.UP:
                if (m_cc.isGrounded)
                {
                    m_yOffset = m_JumpValue;
                    SendMessage("AnimManager",m_InputDir);
                    Game.Instance.soundManager.PlayEffect("Se_UI_Jump");
                }
                break;
          
            case InputDir.DOWN:
                if (m_isSlide == false)
                {
                    m_isSlide = true;
                    m_sliderTime = 0.733f;
                    SendMessage("AnimManager",m_InputDir);
                    Game.Instance.soundManager.PlayEffect("Se_UI_Slide");
                }
                break;
        }
    }

    void MoveControl()
    {
        if (m_targetIndex != m_nowIndex)
        {
            float move = Mathf.Lerp(0,m_xOffset, m_MoveSpeed * Time.deltaTime);
            transform.position += new Vector3(move,0,0);
            m_xOffset -= move;

            if (Mathf.Abs(m_xOffset) < 0.05f)
            {
                m_xOffset = 0;
                m_nowIndex = m_targetIndex;

                switch (m_nowIndex)
                {
                    case 0:
                        transform.position = new Vector3(-2,transform.position.y,transform.position.z);
                        break;
                    case 1:
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        break;
                    case 2:
                        transform.position = new Vector3(2, transform.position.y, transform.position.z);
                        break;

                    default:
                        break;
                }
            }
        }

        if (m_isSlide)
        {
            m_sliderTime -= Time.deltaTime;
            if (m_sliderTime < 0)
            {
                m_isSlide = false;
                m_sliderTime = 0;
            }
        }
    }

    /// <summary>
    /// 最大速度限制
    /// </summary>
    void UpdateSpeed()
    {
        m_moveCount += speed * Time.deltaTime;
        if (m_moveCount > m_moveAddDis)
        {
            m_moveCount = 0;
            if (speed < m_MaxSpeed)
            {
                speed += m_moveAddSpeed;
            }
        }
    }


    int m_Multiply = 1;
    float m_SkillTime;

    IEnumerator MultiplyCor;  //保持双倍金币的唯一性
    /// <summary>
    /// 吃金币
    /// </summary>
    public void HitCoin()
    {
        print("吃金币~~~~~~~");
    }

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
        m_Multiply = 2;
        yield return new WaitForSeconds(m_SkillTime);
        m_Multiply = 1;
    }



    SphereCollider m_MagnetCollider;
    IEnumerator MagnetCor;
    /// <summary>
    /// 吸铁石
    /// </summary>
    void HitMagnet()
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
        m_MagnetCollider.enabled = true;
        yield return new WaitForSeconds(m_SkillTime);
        m_MagnetCollider.enabled = false;
    }

    /// <summary>
    /// 时间增加
    /// </summary>
    public void HitAddTime()
    {
        print("Time Add");
        //发消息 加时间
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
        m_isInvincible = true;
        yield return new WaitForSeconds(m_SkillTime);
        m_isInvincible = false;
    }
}