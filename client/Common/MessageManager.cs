using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public static MessageManager instance;

    public Text messageText;

    void Awake()
    {
        instance = this;
        this.gameObject.SetActive(false);
    }

    public void ShowLog(string message, float time = 1.0f)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(Hide(message, time));
    }

    IEnumerator Hide(string message, float time)
    {
        messageText.text = message;
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
}
