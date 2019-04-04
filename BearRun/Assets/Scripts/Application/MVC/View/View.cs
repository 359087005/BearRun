/****************************************************
    文件：View.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
///View 可执行多个事件
/// </summary>
public abstract class View : MonoBehaviour 
{
    //标识
    public abstract string Name { get; }
    //事件关心列表
    [HideInInspector]
    public List<string> attentionList = new List<string>();

    public virtual void RegisterAttentionEvent()
    {

    }

    //处理事件
    public abstract void HandleEvent(string name,object data);
    //发送事件
    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    protected T GetModel<T>()
        where T : Model
    {
        return MVC.GetModel<T>() as T;
    }
}