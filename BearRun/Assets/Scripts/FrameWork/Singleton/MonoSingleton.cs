/****************************************************
    文件：MonoSingleton.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;

    public static T Instance
    {
        get { return m_instance; }
    }

    protected virtual void Awake()
    {
        m_instance = this as T;
    }
}