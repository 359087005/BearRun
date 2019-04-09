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
    }

    private void Start()
    {
        StartCoroutine(UpdateAction());
    }

    IEnumerator UpdateAction()
    {
        while (true)
        {
            if (!gm.m_isPause && gm.m_isPlay)
            {
                m_yOffset -= gravity * Time.deltaTime;
                m_cc.Move((transform.forward * speed + new Vector3(0, m_yOffset, 0)) * Time.deltaTime);
                MoveControl();
                UpdateSpeed();
                UpdatePositon();
            }
            yield return 0;
        }
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
                }
                break;
            case InputDir.UP:
                if (m_cc.isGrounded)
                {
                    m_yOffset = m_JumpValue;
                    SendMessage("AnimManager",m_InputDir);
                }
                break;
            case InputDir.RIGHT:
                if (m_targetIndex < 2)
                {
                    m_targetIndex++;
                    m_xOffset = 2;
                    SendMessage("AnimManager", m_InputDir);
                }
                break;
            case InputDir.DOWN:
                if (m_isSlide == false)
                {
                    m_isSlide = true;
                    m_sliderTime = 0.733f;
                    SendMessage("AnimManager",m_InputDir);
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
    /// 速度限制
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
}