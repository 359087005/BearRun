/****************************************************
    文件：Magnet.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：吸铁石
*****************************************************/

using UnityEngine;

public class Magnet : Item 
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Consts.TAG_Player)
        {
            HitPlayer(other.transform);
            other.SendMessage("HitItem",ItemKind.magnetItem);
        }
    }

    public override void HitPlayer(Transform pos)
    {
        Game.Instance.soundManager.PlayEffect("Se_UI_Magnet");

        //回收
        //Game.Instance.objectPool.UnSpawn(gameObject);
        Destroy(this.gameObject);
    }

    public override void OnSpawn()
    {
       
    }

    public override void OnUnSpawn()
    {
      
    }

    
}