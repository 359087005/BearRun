/****************************************************
    文件：Consts.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/
using UnityEngine;

public static class Consts
{
    //事件名字
    public const string E_ExitScene = "ExitScene";
    public const string E_EnterScene = "EnterScene";
    public const string E_StartUp = "StartUp";

    //model  

    //view
    public const string V_PlayerMove = "PlayerMove";

    //tag标签
    public const string TAG_Road = "Road";
    public const string TAG_Player = "Player";
}

public enum InputDir
{
    NULL,LEFT,UP,RIGHT,DOWN
}