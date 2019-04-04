/****************************************************
    文件：ObjectPool.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool> 
{
    //路径
    public string ResourcesDir = "";

    Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();

    /// <summary>
    /// 取物体
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject Spawn(string name,Transform trans)
    {
        SubPool pool = null;
        if (!m_pools.ContainsKey(name))
        {
            RegisterNewPool(name,trans);
        }
        pool = m_pools[name];
        return pool.Spawn();
    }
    /// <summary>
    /// 回收一个
    /// </summary>
    /// <param name="go"></param>
    public void UnSpawn(GameObject go)
    {
        SubPool pool = null;

        foreach (SubPool tmpPool in m_pools.Values)
        {
            if (tmpPool.IsContain(go))
            {
                pool = tmpPool;
                break;
            }
        }
        pool.UnSpawn(go);
    }
    /// <summary>
    /// 全体回收
    /// </summary>
    public void UnSpawnAll()
    {
        foreach (SubPool tmpPool in m_pools.Values)
        {
            tmpPool.UnSpawnAll();
        }
    }
    /// <summary>
    /// 新池子创建
    /// </summary>
    /// <param name="names"></param>
    /// <param name="trans"></param>
    public void RegisterNewPool(string names,Transform trans)
    {
        string path = ResourcesDir + "/" + names;
        GameObject go = Resources.Load<GameObject>(path);
        SubPool pool = new SubPool(trans,go);

        m_pools.Add(pool.Name,pool);
    }
}