/****************************************************
    文件：ReusableObject.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public abstract class ReusableObject : MonoBehaviour, IReusable
{
    public abstract void OnSpawn();
    public abstract void OnUnSpawn();
}