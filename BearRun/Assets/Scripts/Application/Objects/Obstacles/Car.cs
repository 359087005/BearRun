/****************************************************
    文件：Car.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class Car : Obstacles 
{
    public bool canMove = false;
    bool isBlock = false;
    public float speed = 10f;


    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if(isBlock && canMove)
        transform.Translate(-transform.forward * speed* Time.deltaTime);
    }

    public override void HitPlayer(Vector3 pos)
    {
        base.HitPlayer(pos);
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void OnUnSpawn()
    {
        isBlock = false;
        base.OnUnSpawn();
    }

    void HitTrigger()
    {
        isBlock = true;
    }
}