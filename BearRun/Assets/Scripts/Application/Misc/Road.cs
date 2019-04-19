/****************************************************
    文件：Road.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class Road : ReusableObject
{
    public override void OnSpawn()
    {
        
    }

    public override void OnUnSpawn()
    {
        //回收路下的item东西
        Transform itemChild = transform.Find("Items");
        if (itemChild != null)
        {
            foreach (Transform child in itemChild)
            {
                if (child != null)
                {
                    Game.Instance.objectPool.UnSpawn(child.gameObject);
                }
            }
        }
    }
}