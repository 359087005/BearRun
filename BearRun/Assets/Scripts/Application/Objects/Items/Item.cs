/****************************************************
    文件：Item.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class Item : ReusableObject
{
    public float speed = 60;

    public void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    public virtual void HitPlayer(Transform pos)
    {

    }

    public override void OnSpawn()
    {

    }

    public override void OnUnSpawn()
    {
        transform.localEulerAngles = Vector3.zero;
    }
}