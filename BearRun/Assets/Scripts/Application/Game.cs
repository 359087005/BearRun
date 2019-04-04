/****************************************************
    文件：Game.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class Game : MonoSingleton<Game> 
{
    protected override void Awake()
    {
        base.Awake();

    }

    public ObjectPool objectPool;
    public SoundManager soundManager;
    public StaticData staticData;
}