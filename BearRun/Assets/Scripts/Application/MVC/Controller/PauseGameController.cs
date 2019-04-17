/****************************************************
    文件：PauseGameController.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class PauseGameController : Controller
{
    public override void Execute(object data)
    {
        GameModel gm = GetModel<GameModel>();
        gm.m_isPause = true;

        UIPause pause = GetView<UIPause>();
        PauseArgs e = data as PauseArgs;
        pause.Show(e);

    }
}