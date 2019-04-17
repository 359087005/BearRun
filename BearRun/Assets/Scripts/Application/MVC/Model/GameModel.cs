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
    public bool m_isPlay = true;
    public bool m_isPause = false;
    public float m_SkillTime = 5;
    public int m_Magnet;
    public int m_Multiple;
    public int m_Invincible;

    public void Init()
    {
        m_Magnet = 1;
        m_Multiple = 2;
        m_Invincible = 3;
        m_SkillTime = 5;
    }
}