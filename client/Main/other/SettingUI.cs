using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingUI : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private float volume = 0.5f;  //初始音量

    public void OnMusicOpenBtnClick()
    {
        audioSource.volume = volume;
    }

    public void OnMusicCloseBtnClick()
    {
        audioSource.volume = 0;
    }

    public void OnLogoutBtnClick()
    {
        Application.Quit();
    }

    public void OnQQBtnClick()
    {
        //TODO
    }

    public void OnWechatBtnClick()
    {
        //TODO
    }

    public void OnVolumeSlider()
    {
        volume = volumeSlider.value;
        audioSource.volume = volume;
    }
}
