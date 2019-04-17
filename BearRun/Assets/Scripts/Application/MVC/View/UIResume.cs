/****************************************************
    文件：UIResume.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIResume : View
{
    public Image imageCount;
    public Sprite[] sprCount;

    public override string Name
    {
        get
        {
            return Consts.V_Resume;
        }
    }

    public override void HandleEvent(string name, object data)
    {

    }

    public void StartCount()
    {
        Show();
        StartCoroutine(IEStartCount());
    }
    IEnumerator IEStartCount()
    {
        int i = 3;
        while (i > 0)
        {
            imageCount.sprite = sprCount[i - 1];
            i--;
            yield return new WaitForSeconds(1f);
            if (i <= 0)
            {
                break;
            }
        }
        Hide();

        //todo
        GameModel gm = GetModel<GameModel>();
        gm.m_isPause = false;
        gm.m_isPlay = true;
    }

    public void Show() { gameObject.SetActive(true); }

    public void Hide() { gameObject.SetActive(false); }
}