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
    public const string E_ExitScene = "ExitScene"; //sceneArgs
    public const string E_EnterScene = "EnterScene";//sceneArgs
    public const string E_StartUp = "StartUp";
    public const string E_EndGame = "EndGame";

    public const string E_PauseGame = "PauseGame";
    public const string E_ResumeGame = "ResumeGame";

    public const string E_UpdateDis = "UpdateDis"; //distanceArgs
    public const string E_UpdateCoin = "UpdateCoin";//CoinArgs
    public const string E_HitAddTime = "HitAddTime";
    public const string E_HitItem = "HitItem"; //吃到的还是点击到的ItemArgs

    public const string E_FinalShowUI = "FinalShowUI";

    public const string E_BriberyClick = "BriberyClick";//贿赂

    //resume播放完成继续游戏
    public const string E_ContinueGame = "ContinueGame";

    //model  
    public const string M_GameModel = "GameModel";
    //view
    public const string V_PlayerMove = "PlayerMove";
    public const string V_AnimationManager = "AnimationManager";
    public const string V_Board = "UIBoard";
    public const string V_Pause = "UIPause";
    public const string V_Resume = "UIResume";
    public const string V_Dead = "UIDead";
    public const string V_FinalScore = "UIFinalScore";
    //tag标签
    public const string TAG_Road = "Road";
    public const string TAG_Player = "Player";
    public const string TAG_BigFence = "BigFence";  //打栅栏
    public const string TAG_SmallFence = "SmallFence";//小 栅栏
    public const string TAG_Block = "Block"; //集装箱
    public const string TAG_SmallBlock = "SmallBlock"; //小集装箱

    public const string TAG_BeforeTrigger = "BeforeTrigger";//物体移动trigger
    public const string Tag_MagnetCollider = "MagnetCollider";//吸铁石collider
}

public enum InputDir
{
    NULL, LEFT, UP, RIGHT, DOWN
}

public enum ItemKind
{
    invincibleItem,
    multipleItem,
    magnetItem
}