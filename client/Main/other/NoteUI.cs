using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoteUI : MonoBehaviour
{
    private static NoteUI instance;
    public static NoteUI Instance { get { return instance; } }

    public Text noteText;

    void Awake()
    {
        instance = this;
    }

    public void UpdateNote(string note)
    {
        noteText.text = note;
    }
}
