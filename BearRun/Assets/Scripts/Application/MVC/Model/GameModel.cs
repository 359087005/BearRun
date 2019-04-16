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

}