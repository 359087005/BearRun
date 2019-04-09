/****************************************************
    文件：StartUpController.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class StartUpController : Controller
{
    public override void Execute(object data)
    {
        //注册controller
        RegisterController(Consts.E_EnterScene,typeof(EnterSceneController));
        //注册model
        RegisterModel(new GameModel());
        //完成跳转场景
        
    }
}