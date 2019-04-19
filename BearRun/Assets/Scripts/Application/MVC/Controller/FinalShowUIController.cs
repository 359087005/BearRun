/****************************************************
    文件：FinalShowUIController.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class FinalShowUIController : Controller
{
    public override void Execute(object data)
    {
        GameModel gm = GetModel<GameModel>();

        UIBoard board = GetView<UIBoard>();
        board.Hide();

        UIFinalScore final = GetView<UIFinalScore>();
        final.Show();
        gm.Exp += board.Coin + board.Distance * (board.GoalCount + 1);

        final.UpdateUI(board.Distance, board.Coin, board.GoalCount,gm.Exp,gm.Level);


        UIDead dead = GetView<UIDead>();
        dead.Hide();


    }
}