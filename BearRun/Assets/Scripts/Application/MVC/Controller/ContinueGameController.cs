/****************************************************
    文件：ContinueGameController.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class ContinueGameController : Controller
{
    public override void Execute(object data)
    {
        GameModel gm = GetModel<GameModel>();

        UIBoard board = GetView<UIBoard>();
        board.MyTime += 20;

        gm.m_isPause = false;
        gm.m_isPlay = true;
    }
}