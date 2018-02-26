using UnityEngine;

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

    public AudioSource bgmAudioSource;
    public AudioClip seaWaveClip;
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
            bgmAudioSource.Pause();
        }
        else
        {
            bgmAudioSource.Play();
        }
    }

    public void PlayEffectSound(AudioClip clip)
    {
        if (!isMute)
        {
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -5));
        }
    }
}
