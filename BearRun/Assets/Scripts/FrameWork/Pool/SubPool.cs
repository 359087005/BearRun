/****************************************************
    文件：SubPool.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using System.Collections.Generic;

public class SubPool 
{
    List<GameObject> m_objects = new List<GameObject>();
    //预设
    GameObject m_prefab;

    public string Name
    {
        get { return m_prefab.name; }
    }
    //预设实例化的父物体  为了整洁。。
    Transform m_parent;

    /// <summary>
    /// 取物体
    /// </summary>
    /// <returns></returns>
    public GameObject Spawn()
    {
        GameObject go = null;
        foreach (GameObject obj in m_objects)
        {
            if (!obj.activeSelf)
            {
                go = obj;
                break;
            }
        }

        if (go == null)
        {
            go = GameObject.Instantiate<GameObject>(m_prefab);
            go.transform.parent = m_parent;
            m_objects.Add(go);
        }

        go.SetActive(true);
        go.SendMessage("OnSpawn",SendMessageOptions.DontRequireReceiver);
        return go;
    }
    /// <summary>
    /// 收物体
    /// </summary>
    /// <param name="go"></param>
    public void UnSpawn(GameObject go)
    {
        if (IsContain(go))
        {
            go.SendMessage("OnUnSpawn",SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }
    /// <summary>
    /// 全部回收
    /// </summary>
    public void UnSpawnAll()
    {
        foreach (GameObject item in m_objects)
        {
            if (item.activeSelf)
            {
                UnSpawn(item);
            }
        }
    }

    public bool IsContain(GameObject go)
    {
        return m_objects.Contains(go);
    }



    public SubPool(Transform parent,GameObject go)
    {
        m_parent = parent;
        m_prefab = go;
    }
}