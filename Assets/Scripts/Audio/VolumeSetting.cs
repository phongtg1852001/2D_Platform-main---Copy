using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider musicMap3Slider;
    [SerializeField] private Slider musicMap2Slider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("musicMap3Volume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetMusicMap3Volume();
            SetMusicMap2Volume();
        }
    }

    public void SetMusicVolume()
    {
        if (musicSlider != null)
        {
            float volume = musicSlider.value;
            myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }
    }

    public void SetMusicMap3Volume()
    {
        if (musicMap3Slider != null)
        {
            float volume = musicMap3Slider.value;
            myMixer.SetFloat("MusicMap3", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("musicMap3Volume", volume);
        }
    }
    public void SetMusicMap2Volume()
    {
        if(musicMap2Slider != null)
        {
            float volume = musicMap2Slider.value;
            myMixer.SetFloat("MusicMap2", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("musicMap2Volume", volume);
        }
    }

    private void LoadVolume()
    {
        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            SetMusicVolume();
        }

        if (musicMap3Slider != null)
        {
            musicMap3Slider.value = PlayerPrefs.GetFloat("musicMap3Volume");
            SetMusicMap3Volume();
        }
        if(musicMap2Slider != null)
        {
            musicMap2Slider.value = PlayerPrefs.GetFloat("musicMap2Volume");
            SetMusicMap2Volume();
        }
    }
}
