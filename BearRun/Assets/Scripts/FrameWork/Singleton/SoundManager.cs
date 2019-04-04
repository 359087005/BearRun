/****************************************************
    文件：SoundManager.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager> 
{
    AudioSource m_bg;
    AudioSource m_effect;

    public string ResourcesDir = "";

    protected override void Awake()
    {
        base.Awake();
        m_bg = gameObject.AddComponent<AudioSource>();
        m_bg.playOnAwake = false;
        m_bg.loop = true;

        m_effect = gameObject.AddComponent<AudioSource>();
    }
    /// <summary>
    /// 播放BG
    /// </summary>
    /// <param name="audioName"></param>
    public void PlayBG(string audioName)
    {
        if (m_bg.clip == null ||(m_bg.clip.name != audioName))
        {
            m_bg.clip = LoadMusic(audioName);
            m_bg.Play();
        }
    }

    public void PlayEffect(string audioName)
    {
        m_effect.PlayOneShot(LoadMusic(audioName));
    }

    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    AudioClip LoadMusic(string name)
    {
        string path = ResourcesDir + "/" + name;
        AudioClip clip = Resources.Load<AudioClip>(path);
        if (clip != null)
            return clip;
        else
        {
            Debug.LogError("音频不存在");
            return null;
        }
    }
}