/****************************************************
    文件：UIPause.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : View
{
    public Text texDis;
    public Text texCoin;
    public Text texScore;

    public override string Name
    {
        get
        {
            return Consts.V_Pause;
        }
    }

    public override void HandleEvent(string name, object data)
    {
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show(PauseArgs p)
    {
        gameObject.SetActive(true);
        DataUpdate(p);
    }

    public void OnResumeClick()
    {
        Hide();
        SendEvent(Consts.E_ResumeGame);
    }

    public void DataUpdate(PauseArgs p)
    {
        texDis.text = p.distance.ToString();
        texCoin.text = p.coin.ToString();
        texScore.text = p.goal.ToString();
    }
}