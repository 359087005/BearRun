/****************************************************
    文件：Controller.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public abstract class Controller 
{
    public abstract void Execute(object data);

    //获取模型
    protected T GetModel<T>()
       where T : Model
    {
        return MVC.GetModel<T>() as T;
    }
    //获取视图
    protected T GetView<T>()
     where T : View
    {
        return MVC.GetView<T>() as T;
    }

    //注册模型
    protected  void RegisterModel(Model model)
    {
        MVC.RegisterModel(model);
    }
    //注册视图
    protected void RegisterView(View view)
    {
        MVC.RegisterView(view);
    }
    //注册控制器
    protected void RegisterController(string eventName,Type type)
    {
        MVC.RegisterController(eventName,type);
    }
}