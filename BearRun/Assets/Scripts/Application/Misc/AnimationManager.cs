/****************************************************
    文件：AnimManager.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animation anim;
    Action playAnim;

    void Awake()
    {
        anim = this.GetComponent<Animation>();
        playAnim = PlayRun;
    }

    void Update()
    {
        if (playAnim != null)
        {
            playAnim();
        }
    }

    void PlayRun()
    {
        anim.Play("run");
    }

    void PlayLeft()
    {
        anim.Play("left_jump");
        if (anim["left_jump"].normalizedTime > 0.95f)
        {
            playAnim = PlayRun;
        }
    }
    void PlayRight()
    {
        anim.Play("right_jump");
        if (anim["right_jump"].normalizedTime > 0.95f)
        {
            playAnim = PlayRun;
        }
    }
    void PlayRoll()
    {
        anim.Play("roll");
        if (anim["roll"].normalizedTime > 0.95f)
        {
            playAnim = PlayRun;
        }
    }
    void PlayJump()
    {
        anim.Play("jump");
        if (anim["jump"].normalizedTime > 0.95f)
        {
            playAnim = PlayRun;
        }
    }

    public void AnimManager(InputDir dir)
    {
        switch (dir)
        {
            case InputDir.LEFT:
                playAnim = PlayLeft;
                break;
            case InputDir.RIGHT:
                playAnim = PlayRight;
                break;
            case InputDir.UP:
                playAnim = PlayJump;
                break;
            case InputDir.DOWN:
                playAnim = PlayRoll;
                break;
        }
    }
}
