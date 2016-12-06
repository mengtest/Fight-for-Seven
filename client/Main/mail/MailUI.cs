using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MailUI : MonoBehaviour
{
    private static MailUI instance;
    public static MailUI Instance { get { return instance; } }

    public Text contentText;
    public Button removeBtn;

    void Awake()
    {
        instance = this;
    }

    public void UpdateText(string content)
    {
        contentText.text = content;
    }

    public void ShowRemoveBtn()
    {
        removeBtn.gameObject.SetActive(true);
    }

    public void HideRemoveBtn()
    {
        removeBtn.gameObject.SetActive(false);
    }

    public void OnRemoveBtnClick()
    {
        MailManager.Instance.RemoveMail();
    }
}
