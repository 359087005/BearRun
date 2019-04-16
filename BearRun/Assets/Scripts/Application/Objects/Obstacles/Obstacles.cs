/****************************************************
    文件：Obstacles.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class Obstacles : ReusableObject
{
    protected Transform effectParent;
    public virtual void Awake()
    {
        effectParent = GameObject.Find("EffectParent").transform;
    }

    public override void OnSpawn()
    {

    }

    public override void OnUnSpawn()
    {

    }

    public virtual void HitPlayer(Vector3 pos)
    {
        //生成特效
        GameObject go = Game.Instance.objectPool.Spawn("FX_ZhuangJi", effectParent);
        go.transform.position = pos;
        //回收
        //Game.Instance.objectPool.UnSpawn(this.gameObject);
        Destroy(this.gameObject);
    }
}