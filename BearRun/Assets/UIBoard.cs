/****************************************************
    文件：UIBoard.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

public class UIBoard : View
{
    #region 字段
    int m_Coin = 0;
     int m_Distance=  0;

    public Text texCoin;
    public Text texDistance;
    #endregion
    #region 属性
    public override string Name
    {
        get
        {
            return Consts.V_Board;
        }
    }

    public int Coin
    {
        get
        {
            return m_Coin;
        }

        set
        {
            m_Coin = value;
            texCoin.text = value.ToString();
        }
    }

    public int Distance
    {
        get
        {
            return m_Distance;
        }

        set
        {
            m_Distance = value;
            texDistance.text = value.ToString() + "米"; 
        }
    }
    #endregion

    public override void RegisterAttentionEvent()
    {
        attentionList.Add(Consts.E_UpdateDis);
    }

    public override void HandleEvent(string name, object data)
    {
        switch (name)
        {
            case Consts.E_UpdateDis:
                DistanceArgs e = data as DistanceArgs;
                Distance = e.distance;
                break;
            default:
                break;
        }
    }
}