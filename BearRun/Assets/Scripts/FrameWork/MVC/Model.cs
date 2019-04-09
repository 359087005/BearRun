/****************************************************
    文件：Model.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public abstract class Model
{
    public abstract string Name { get; }

    protected void SendEvent(string eventName,object data = null)
    {
        MVC.SendEvent(eventName,data);
    }
}