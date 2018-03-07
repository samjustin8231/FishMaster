using UnityEngine;

/**
 * 音效和bgm控制类
 * 挂在各个scene的ScriptHolder上
 * */
public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private bool isMute = false;
    public bool IsMute
    {
        get
        {
            return isMute;
        }
    }

    public AudioSource bgmAudioSource;	//背景音乐
    public AudioClip seaWaveClip;		//音效
    public AudioClip goldClip;
    public AudioClip rewardClip;
    public AudioClip fireClip;
    public AudioClip changeClip;
    public AudioClip lvUpClip;

    void Awake()
    {
        _instance = this;
        isMute = (PlayerPrefs.GetInt("mute", 0) == 0) ? false : true;
        DoMute();
    }

    public void SwitchMuteState(bool isOn)
    {
        isMute = !isOn;
        DoMute();
    }

    void DoMute()
    {
        if (isMute)
        {
            bgmAudioSource.Pause();	//背景音乐pause
        }
        else
        {
            bgmAudioSource.Play();	//背景音乐播放
        }
    }

    public void PlayEffectSound(AudioClip clip)
    {
        if (!isMute)
        {
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -5));	//播放音效
        }
    }
}
