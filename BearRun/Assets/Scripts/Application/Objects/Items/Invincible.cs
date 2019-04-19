/****************************************************
    文件：Invincible.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class Invincible : Item 
{

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
            other.SendMessage("HitItem", ItemKind.invincibleItem);
        }
    }

    public override void HitPlayer(Transform pos)
    {
        //声音
        Game.Instance.soundManager.PlayEffect("Se_UI_Whist");
        //回收
        Game.Instance.objectPool.UnSpawn(gameObject);
        //Destroy(this.gameObject);
    }
}