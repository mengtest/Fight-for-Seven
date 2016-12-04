using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeBg : MonoBehaviour
{
    public Image bg;
    public AudioSource audioSource;
    public Sprite[] sprites;
    public AudioClip[] musics;
    private int num = 0;

	public void OnLeftBtnClick()
    {
        --num;
        if (num < 0)
        {
            num += sprites.Length;
        }
        bg.sprite = sprites[num];
        audioSource.clip = musics[num];
        audioSource.Play();
    }

    public void OnRightBtnClick()
    {
        ++num;
        num %= sprites.Length;
        bg.sprite = sprites[num];
        audioSource.clip = musics[num];
        audioSource.Play();
    }
}
