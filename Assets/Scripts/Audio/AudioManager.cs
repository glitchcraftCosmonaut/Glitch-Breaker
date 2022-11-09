using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : PersistentSingleton<AudioManager>
{
        private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectSlider;
    private float backgroundFloat, soundEffectFloat;
    public AudioSource backgroundAudio;
    AudioSetting audioSetting;

    const float MIN_PITCH = 0.9f;
    const float MAX_PITCH = 1.1f;

    private void Start()
    {
        audioSetting = GetComponent<AudioSetting>();
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat = .125f;
            soundEffectFloat = .75f;
            backgroundSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectSlider.value = soundEffectFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectSlider.value);
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)    
        {
            SaveSoundSettings();
        }
    }
    public void UpdateSound()
    {
        audioSetting.backgroundAudio.volume = backgroundSlider.value;
        audioSetting.sFXPlayer.volume = soundEffectSlider.value;
        // backGroundMusic.backgroundMusic.volume = backgroundSlider.value;
        // audioDatas.volume = soundEffectSlider.value;
        // backGroundMusic.volume = backgroundSlider.value;
        // AudioData.Instance.PlayMusic(backGroundMusic);
        
        // for(int i = 0; i < soundEffectAudio.Length; i++)
        // {
        //     soundEffectAudio[i].volume = soundEffectSlider.value;
        // }
    }
}

