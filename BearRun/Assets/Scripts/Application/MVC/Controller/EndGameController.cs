/****************************************************
    文件：EndGameController.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class EndGameController : Controller
{
    public override void Execute(object data)
    {
        GameModel gm = GetModel<GameModel>();

        gm.m_isPlay = false;   
    }
}