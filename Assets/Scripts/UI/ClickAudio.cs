using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管理UI音效
/// </summary>
public class ClickAudio : MonoBehaviour
{
    private AudioSource m_AudioSource;
    private ManagerVars vars;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        vars = ManagerVars.GetManagerVars();
        EventCenter.AddListener(EventDefine.PlayClikAudio, PlayButtonAudio);
        EventCenter.AddListener<bool>(EventDefine.IsMusicOn, SwitchMusic);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.PlayClikAudio, PlayButtonAudio);
        EventCenter.RemoveListener<bool>(EventDefine.IsMusicOn, SwitchMusic);
    }
    /// <summary>
    /// 播放按下按钮的音效
    /// </summary>
    private void PlayButtonAudio()
    {
        m_AudioSource.PlayOneShot(vars.buttonClip);
    }
    /// <summary>
    /// 切换音效是否播放
    /// </summary>
    /// <param name="value"></param>
    private void SwitchMusic(bool value)
    {
        // 使 AudioSource 静音/取消静音, 静音时将音量设置为0
        m_AudioSource.mute = !value;
    }
    
}
