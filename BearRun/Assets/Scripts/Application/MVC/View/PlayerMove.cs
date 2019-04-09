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
    float m_offset;   //左移右移偏移量
    float m_MoveSpeed = 13;

    private void Awake()
    {
        m_cc = this.GetComponent<CharacterController>();
    }

    private void Start()
    {
        StartCoroutine(UpdateAction());
    }

    IEnumerator UpdateAction()
    {
        while (true)
        {
            m_cc.Move(transform.forward * speed * Time.deltaTime);
            UpdatePositon();
            yield return 0;
        }
    }
    /// <summary>
    /// 获取朝向
    /// </summary>
    void GetInputDir()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_InputDir = InputDir.NULL;
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
                    m_offset = -2;
                }
                break;
            case InputDir.UP:
                break;
            case InputDir.RIGHT:
                if (m_targetIndex < 2)
                {
                    m_targetIndex++;
                    m_offset = 2;
                }
                break;
            case InputDir.DOWN:
                break;
        }
    }

    void MoveControl()
    {
        if (m_targetIndex != m_nowIndex)
        {
            float move = Mathf.Lerp(0,m_offset, m_MoveSpeed * Time.deltaTime);
        }
    }
}