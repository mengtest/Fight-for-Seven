using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatUI : MonoBehaviour
{
    public Image switchBtn;
    public Sprite keyboardSprite;
    public Sprite soundSprite;
    public InputField inputContent;
    public GameObject emotionPanel;
    public GameObject chatLeftItemPrefab;  //别人的聊天框
    public GameObject chatRightItemPrefab;  //自己的聊天框
    public Transform chatItemParent;
    public Scrollbar scrollbarVertical;

    private bool isKeyboard = true;  //目前的状态
    private float chatHeight = 10.0f;  //聊天内容top高度，初始有间隔
    private float iconHeight = 30.0f;  //icon高度
    private float minWidth = 60.0f;  //单行最短长度
    private float maxWidth = 160.0f;  //单行最长长度

    void Start()
    {
        scrollbarVertical.onValueChanged.AddListener(ScrollBarValueChanged);
    }

    void Update()
    {
        //回车键提交字的聊天内容
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnSubmitBtnClick();
        }

        //F1构造别人的聊天内容
        if (Input.GetKeyDown(KeyCode.F1))
        {
            OnOtherSubmitBtnClick();
        }
    }

    public void OnEmotionBtnClick()
    {
        if (emotionPanel.activeInHierarchy)
        {
            emotionPanel.SetActive(false);
        }
        else
        {
            emotionPanel.SetActive(true);
        }
    }

    public void OnSwitchBtnClick()
    {
        if (isKeyboard)
        {
            switchBtn.sprite = soundSprite;
            isKeyboard = false;  //切换到语音状态
        }
        else
        {
            switchBtn.sprite = keyboardSprite;
            isKeyboard = true;  //切换到键盘状态
        }
    }

    bool isAddMessage = false;
    public void ScrollBarValueChanged(float value)  //保证每次有消息自动滑动到最底部，同时保证没有消息到达时允许向上滑动
    {
        if (isAddMessage)
        {
            scrollbarVertical.value = 0;
            isAddMessage = false;
        }
    }

    //构造自己提交的聊天消息
    public void OnSubmitBtnClick()
    {
        if (inputContent.text == string.Empty || inputContent.text.Length > 50)  //没输入
        {
            MessageManager.instance.ShowLog("文字长度不合法");
            inputContent.text = "";
            return;
        }

        string content = inputContent.text;
        ChatItem item = new ChatItem(PlayerInfo.Instance.Username, content, ChatType.World);
        GameObject tempGo = Instantiate(chatRightItemPrefab);
        tempGo.transform.SetParent(chatItemParent);
        tempGo.transform.localPosition = Vector3.zero;
        tempGo.transform.localScale = Vector3.one;

        //更新内容
        tempGo.GetComponent<ChatItemUI>().UpdateConent(item.content);
        tempGo.GetComponent<ChatItemUI>().UpdateUsername(item.username);

        //isAddMessage = true;
        FitScreen(tempGo);  //使物体适应屏幕

        //存储itemUI
        ChatManager.Instance.itemUIList.Add(tempGo.GetComponent<ChatItemUI>());
        Clear();
    }

    //构造别人到达的聊天消息
    public void OnOtherSubmitBtnClick()
    {
        string content = "这是我想说的话，你想听吗？？？我爱你喔~~~";
        ChatItem item = new ChatItem("我是其他人", content, ChatType.World);
        GameObject tempGo = Instantiate(chatLeftItemPrefab);
        tempGo.transform.SetParent(chatItemParent);
        tempGo.transform.localPosition = Vector3.zero;
        tempGo.transform.localScale = Vector3.one;

        //更新内容
        tempGo.GetComponent<ChatItemUI>().UpdateConent(item.content);
        tempGo.GetComponent<ChatItemUI>().UpdateUsername(item.username);

        //isAddMessage = true;
        FitScreen(tempGo);  //使物体适应屏幕

        //存储itemUI
        ChatManager.Instance.itemUIList.Add(tempGo.GetComponent<ChatItemUI>());
        Clear();
    }

    void FitScreen(GameObject tempGo)
    {
        //适应聊天框
        Text tempChatText = tempGo.transform.Find("content").GetComponent<Text>();
        if (tempChatText.preferredWidth + 10.0f < minWidth)  //单行长度太短
        {
            tempGo.GetComponent<RectTransform>().sizeDelta = new Vector2(minWidth, tempChatText.preferredHeight + 20.0f);
            tempChatText.GetComponent<RectTransform>().sizeDelta = new Vector2(minWidth, tempChatText.preferredHeight + 20.0f);
        }
        else if (tempChatText.preferredWidth + 10.0f > maxWidth)  //单行长度太长
        {
            tempGo.GetComponent<RectTransform>().sizeDelta = new Vector2(maxWidth, tempChatText.preferredHeight + 20.0f);
            tempChatText.GetComponent<RectTransform>().sizeDelta = new Vector2(maxWidth - 10.0f, tempChatText.preferredHeight + 20.0f);
        }
        else  //让文字自适应聊天框
        {
            tempGo.GetComponent<RectTransform>().sizeDelta = new Vector2(tempChatText.preferredWidth + 10.0f, tempChatText.preferredHeight + 20.0f);
            tempChatText.GetComponent<RectTransform>().sizeDelta = new Vector2(tempChatText.preferredWidth, tempChatText.preferredHeight + 20.0f);
        }

        tempChatText.SetVerticesDirty();  //???作用未知
        tempGo.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -chatHeight);  //设置anchored，别人的在左边，自己的在右边
        chatHeight += (tempChatText.preferredHeight + 20.0f) + iconHeight + 10.0f;  //增加chatHeight高度，包括文字背景，icon和间隔
        if (chatHeight > chatItemParent.GetComponent<RectTransform>().sizeDelta.y)  //超出父容器，让父容器扩大
        {
            chatItemParent.GetComponent<RectTransform>().sizeDelta = new Vector2(chatItemParent.GetComponent<RectTransform>().sizeDelta.x, chatHeight);
        }
    }

    void Clear()
    {
        //移除过多的聊天框
        if (ChatManager.Instance.itemUIList.Count > 10)
        {
            Destroy(ChatManager.Instance.itemUIList[0].gameObject);
            ChatManager.Instance.itemUIList.RemoveAt(0);

            //重新排布UI
            chatHeight = 10.0f;
            chatItemParent.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 250.0f);
            foreach (var item in ChatManager.Instance.itemUIList)
            {
                FitScreen(item.gameObject);

            }
        }
        isAddMessage = true;
        scrollbarVertical.value = 0.1f;  //利用scrollbar调整排版
        inputContent.text = "";
    }
}
