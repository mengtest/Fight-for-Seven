using UnityEngine;
using System.Collections;

public class NoteManager : MonoBehaviour
{
    private static NoteManager instance;
    public static NoteManager Instance { get { return instance; } }

    private string note;

    void Awake()
    {
        instance = this;

        Load();
    }

    void Start()
    {
        UpdateUI();
    }

    //模仿从服务器获取活动公告
    void Load()
    {
        note = "在竞赛胜利10场";
    }

    void UpdateUI()
    {
        NoteUI.Instance.UpdateNote(note);
    }
}
