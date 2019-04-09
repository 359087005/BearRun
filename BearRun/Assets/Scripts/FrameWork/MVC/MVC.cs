/****************************************************
    文件：MVC.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

public static class MVC 
{
    public static Dictionary<string, Model> modelDic = new Dictionary<string, Model>();
    public static Dictionary<string, View> viewDic = new Dictionary<string, View>();
    public static Dictionary<string, Type> commandMap = new Dictionary<string, Type>();

    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="view"></param>
    public static void RegisterView(View view)
    {
        if (viewDic.ContainsKey(view.name))
        {
            viewDic.Remove(view.name);
        }
        view.RegisterAttentionEvent();
        viewDic.Add(view.Name,view);
    }
    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="model"></param>
    public static void RegisterModel(Model model)
    {
        modelDic.Add(model.Name, model);
    }
    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="controllerType"></param>
    public static void RegisterController(string eventName, Type controllerType)
    {
        commandMap.Add(eventName,controllerType);
    }
    /// <summary>
    /// 获取
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetModel<T>()
        where T:Model
    {
        foreach (var item in modelDic.Values)
        {
            if (item is T)
                return (T)item;
        }
        return null;
    }
    /// <summary>
    /// 获取
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetView<T>() 
        where T : View
    {
        foreach (var item in viewDic.Values)
        {
            if (item is T)
                return (T)item;
        }
        return null;
    }

    public static void SendEvent(string eventName,object data = null)
    {
        //controller执行
        if (commandMap.ContainsKey(eventName))
        {
            Type t = commandMap[eventName];
            Controller c = Activator.CreateInstance(t) as Controller;
            c.Execute(data);
        }

        //view 执行
        foreach (var item in viewDic.Values)
        {
            if (item.attentionList.Contains(eventName))
            {
                item.HandleEvent(eventName,data);
            }
        }
    }
}