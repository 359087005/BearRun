/****************************************************
    文件：Coin.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections;
using UnityEngine;

public class Coin : Item 
{
    Transform effectParent;

    public float coinSpeed = 40f;

    private void Awake()
    {
        effectParent = GameObject.Find("EffectParent").transform;
    }

    public override void HitPlayer(Transform pos)
    {
        //特效
        GameObject go= Game.Instance.objectPool.Spawn("FX_JinBi", effectParent);
        go.transform.position = pos.position;
        //声音
        Game.Instance.soundManager.PlayEffect("Se_UI_JinBi");

        //回收
        Game.Instance.objectPool.UnSpawn(gameObject);
        //Destroy(this.gameObject);
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void OnUnSpawn()
    {
        base.OnUnSpawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Consts.TAG_Player)
        {
            HitPlayer(other.transform);
            other.SendMessage("HitCoin", SendMessageOptions.RequireReceiver);
        }
        else if (other.tag == Consts.Tag_MagnetCollider)
        {
            //飞向主角
            StartCoroutine(HitMagnet(other.transform));
        }
    }

    IEnumerator HitMagnet(Transform trans)
    {
        bool isLoop = true;
        while (isLoop)
        {
            transform.position = Vector3.Lerp(transform.position,trans.position,coinSpeed*Time.deltaTime);
            if (Vector3.Distance(transform.position, trans.position) < 0.5f)
            {
                isLoop = false;
                HitPlayer(trans.transform);
                trans.parent.SendMessage("HitCoin",SendMessageOptions.RequireReceiver);
            }
            yield return 0;
        }
    }
}