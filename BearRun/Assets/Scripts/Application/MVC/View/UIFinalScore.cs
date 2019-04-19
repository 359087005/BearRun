/****************************************************
    文件：UIFinalScore.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

public class UIFinalScore : View
{
    public override string Name
    {
        get
        {
            return Consts.V_FinalScore;
        }
    }

    public override void HandleEvent(string name, object data)
    {
        
    }

    public void Show() { gameObject.SetActive(true); }
    public void Hide() { gameObject.SetActive(false); }

    /// <summary>
    /// 更新UI
    /// </summary>
    public void UpdateUI(int dis,int coin,int goal,int exp,int level)
    {
        //距离
        texDis.text = dis.ToString();
        //金币
        texCoin.text = coin.ToString();
        //得分
        texScore.text = (dis*(goal+1)+coin).ToString();

        texGoal.text = goal.ToString();

        texExp.text = exp.ToString() + "/" + (10 + level * 3);

        expSlider.value = (float)exp / (10 + level * 3);

        texLevel.text = level.ToString() + "级";

    }

    public Text texDis;
    public Text texCoin;
    public Text texScore;
    public Text texGoal;
    public Text texExp;
    public Slider expSlider;
    public Text texLevel;
}