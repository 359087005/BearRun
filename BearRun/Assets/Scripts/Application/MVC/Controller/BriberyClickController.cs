/****************************************************
    文件：BriberyClickController.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class BriberyClickController : Controller
{
    public override void Execute(object data)
    {
        CoinArgs e = data as CoinArgs;
        UIDead dead = GetView<UIDead>();
        //花钱
        //若  成功
        //贿赂次数增加
        dead.Hide();
        UIResume resume = GetView<UIResume>();
        resume.StartCount();

    }
}