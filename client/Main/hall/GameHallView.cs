using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHallView : MonoBehaviour
{
    private static GameHallView instance;
    public static GameHallView Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }

    public Button multiplyBtn;  // 多人游戏
    public Button singleBtn;  // 人机对战
    public Button storyBtn;  // 剧情模式

    public Button leftBtn;
    public Button rightBtn;
    public Button closeBtn;
}
