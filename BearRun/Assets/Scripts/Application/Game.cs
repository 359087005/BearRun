/****************************************************
    文件：Game.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(StaticData))]
public class Game : MonoSingleton<Game>
{
    [HideInInspector]
    public ObjectPool objectPool;
    [HideInInspector]
    public SoundManager soundManager;
    [HideInInspector]
    public StaticData staticData;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        objectPool = ObjectPool.Instance;
        soundManager = SoundManager.Instance;
        staticData = StaticData.Instance;

        //游戏启动

        //初始化
        RegisterController(Consts.E_StartUp, typeof(StartUpController));
        //跳场景
        Game.Instance.LoadLevel(2);
    }

    public void LoadLevel(int level)
    {
        //结束场景事件
        ScenesArgs e = new ScenesArgs()
        {
            scenesIndex = SceneManager.GetActiveScene().buildIndex
        };

        SendEvent(Consts.E_ExitScene, e);

        //开始新场景事件
        SceneManager.LoadScene(level);
    }

    //进入新场景
    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("Enter New Scene....");
        //开始场景事件
        ScenesArgs e = new ScenesArgs()
        {
            scenesIndex = level
        };

        SendEvent(Consts.E_EnterScene, e);
    }

    void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    void RegisterController(string eventName, Type type)
    {
        MVC.RegisterController(eventName, type);
    }
}