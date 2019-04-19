/****************************************************
    文件：GameModel.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class GameModel : Model
{
    public override string Name
    {
        get
        {
            return Consts.M_GameModel;
        }
    }

    public int Exp
    {
        get
        {
            return m_Exp;
        }

        set
        {
            while (value > 10 + m_Level * 3)
            {
                value -= 10 + m_Level * 3;
                m_Level++;
            }
            m_Exp = value;
        }
    }

    public int Level
    {
        get
        {
            return m_Level;
        }

        set
        {
            m_Level = value;
        }
    }

    public bool m_isPlay = true;
    public bool m_isPause = false;
    public float m_SkillTime = 5;
    public int m_Magnet;
    public int m_Multiple;
    public int m_Invincible;
    private int m_Level;
    private int m_Exp;

    public void Init()
    {
        m_Magnet = 1;
        m_Multiple = 2;
        m_Invincible = 3;
        m_SkillTime = 5;
        m_Exp = 0;
        m_Level = 1;
    }
}