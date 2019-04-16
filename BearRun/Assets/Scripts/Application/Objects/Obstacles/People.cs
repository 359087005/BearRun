/****************************************************
    文件：People.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections;
using UnityEngine;

public class People : Obstacles
{
    public bool isHit = false;
    public float speed = 10f;
    public bool isFly = false;

    Animation anim;

    public override void Awake()
    {
        base.Awake();
        anim = GetComponentInChildren<Animation>();
    }

    public override void HitPlayer(Vector3 pos)
    {
        Debug.Log("HitPlayer...");
        //生成特效
        GameObject go = Game.Instance.objectPool.Spawn("FX_ZhuangJi", effectParent);
        go.transform.position = pos;
        isHit = false;
        isFly = true;
        anim.Play("fly");
    }

    public override void OnSpawn()
    {
        anim.Play("run");
        base.OnSpawn();
    }

    public override void OnUnSpawn()
    {
        isHit = false; isFly = false;
        anim.transform.localPosition = Vector3.zero;
        base.OnUnSpawn();
    }

    void HitTrigger()
    {
        Debug.Log("HitTrigger...");
        isHit = true;
    }

    //IEnumerator HuiShou()
    //{
    //    yield return new WaitForSeconds(3f);
    //    Game.Instance.objectPool.UnSpawn(this.gameObject);
    //}


    private void Update()
    {
        if (isHit)
            transform.position -= new Vector3(0, 0, speed) * Time.deltaTime;
        if (isFly)
        {
            transform.position += new Vector3(0, speed, speed) * Time.deltaTime;
        }
    }
}