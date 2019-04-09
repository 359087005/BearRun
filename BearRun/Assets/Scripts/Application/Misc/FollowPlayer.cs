/****************************************************
    文件：FollowPlayer.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：摄像机跟随玩家
*****************************************************/

using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{
    Transform m_Player;
    Vector3 m_offset;

    float speed = 20;

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag(Consts.TAG_Player).transform;
        m_offset = transform.position - m_Player.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,m_Player.position + m_offset,speed * Time.deltaTime);
    }
}