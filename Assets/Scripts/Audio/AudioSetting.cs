using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : Singleton<AudioSetting>
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private float backgroundFloat, soundEffectFloat;
    public AudioSource sFXPlayer;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectAudio;




    protected override void Awake()
    {
        base.Awake();
        ContinueSetting();
    }


    private void ContinueSetting()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
        backgroundAudio.volume = backgroundFloat;
        sFXPlayer.volume = soundEffectFloat;
    }
    public void PlaySFX(AudioData audioData)
    {
        // sFXPlayer.clip = audioClip;
        // sFXPlayer.volume = volume;
        // sFXPlayer.Play();
        sFXPlayer.PlayOneShot(audioData.audioClip, audioData.volume);
    }

}

[System.Serializable]
public class AudioData
{
    public AudioClip audioClip;
    public float volume;
}