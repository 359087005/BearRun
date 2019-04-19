/****************************************************
    文件：UIDead.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class UIDead : View
{
    //贿赂次数
    int m_BriberyTime;

    public override string Name
    {
        get
        {
            return Consts.V_Dead;
        }
    }

    public int BriberyTime
    {
        get
        {
            return m_BriberyTime;
        }

        set
        {
            m_BriberyTime = value;
        }
    }

    public override void HandleEvent(string name, object data)
    {
       
    }

    public void Show() { gameObject.SetActive(true); }
    public void Hide() { gameObject.SetActive(false); }

    /// <summary>
    /// 鼠标点击拒绝贿赂
    /// </summary>
    public void OnCancleClick()
    {
        SendEvent(Consts.E_FinalShowUI);
    }

    /// <summary>
    /// 贿赂
    /// </summary>
    public void OnBriberyClick()
    {
        SendEvent(Consts.E_BriberyClick,BriberyTime * 500);
    }

    private void Awake()
    {
        m_BriberyTime = 0;
    }
}