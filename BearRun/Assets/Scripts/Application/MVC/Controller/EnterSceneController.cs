/****************************************************
    文件：EnterSceneController.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class EnterSceneController : Controller
{
    public override void Execute(object data)
    {
        ScenesArgs e = data as ScenesArgs;
        switch (e.scenesIndex)
        {
            case 1:
                break;
            case 2:
                RegisterView(GameObject.FindWithTag(Consts.TAG_Player).GetComponent<PlayerMove>());
                RegisterView(GameObject.FindWithTag(Consts.TAG_Player).GetComponent<AnimationManager>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIBoard").GetComponent<UIBoard>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIPause").GetComponent<UIPause>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIResume").GetComponent<UIResume>());
                break;
        }
    }
}