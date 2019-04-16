/****************************************************
    文件：Effect.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections;
using UnityEngine;

public class Effect : ReusableObject
{
    public float delayTime = 1;

    public override void OnSpawn()
    {
        StartCoroutine(DestroyCoroutine());
    }

    public override void OnUnSpawn()
    {
        StopAllCoroutines();
    }
    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(delayTime);
        Game.Instance.objectPool.UnSpawn(this.gameObject);
    }

}