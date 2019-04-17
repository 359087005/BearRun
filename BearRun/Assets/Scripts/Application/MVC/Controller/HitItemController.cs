/****************************************************
    文件：HitItemController.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class HitItemController : Controller
{
    public override void Execute(object data)
    {
        ItemArgs e = data as ItemArgs;
        PlayerMove player = GetView<PlayerMove>();
        GameModel gm = GetModel<GameModel>();
        UIBoard ui = GetView<UIBoard>();
        switch (e.kind)
        {
            case ItemKind.invincibleItem:
                player.HitInvincible();
                ui.HitInvincible();
                gm.m_Invincible -= e.count;
                break;
            case ItemKind.multipleItem:
                player.HitMultiply();
                ui.HitMultiply();
                gm.m_Multiple -= e.count;
                break;
            case ItemKind.magnetItem:
                player.HitMagnet();
                ui.HitMagnet();
                gm.m_Magnet -= e.count;
                break;
        }
        ui.UpdateUI();

    }
}