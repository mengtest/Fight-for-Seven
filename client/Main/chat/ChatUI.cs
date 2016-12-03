using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatUI : MonoBehaviour
{
    public Image switchBtn;
    public Sprite keyboardSprite;
    public Sprite soundSprite;
    public InputField inputContent;
    public GameObject chatLeftItemPrefab;  //别人的聊天框
    public GameObject chatRightItemPrefab;  //自己的聊天框
    public Transform chatItemParent;
    public Scrollbar scrollbarVertical;

    private bool isKeyboard = true;  //目前的状态
    private float chatHeight = 10.0f;  //聊天内容top高度，初始有间隔
    private float iconHeight = 30.0f;  //icon高度

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
    public void OnScrollBarValueChanged(float value)  //保证每次有消息自动滑动到最底部，同时保证没有消息到达时允许向上滑动
    {
        if (isAddMessage)
        {
            scrollbarVertical.value = 0;
            isAddMessage = false;
        }
    }

    void Update()
    { 
        //回车键提交字的聊天内容
        if (Input.GetKeyDown(KeyCode.Return) && inputContent.text != string.Empty)
        {
            OnSubmitBtnClick();
        }

        //F1构造别人的聊天内容
        if (Input.GetKeyDown(KeyCode.F1))
        {
            OnOtherSubmitBtnClick();
        }
    }

    //构造自己提交的聊天消息
    public void OnSubmitBtnClick()
    {
        string content = inputContent.text;
        ChatItem item = new ChatItem(PlayerInfo.Instance.Username, content, ChatType.World);
        GameObject tempGo = Instantiate(chatRightItemPrefab);
        tempGo.transform.SetParent(chatItemParent);
        tempGo.transform.localPosition = Vector3.zero;
        tempGo.transform.localScale = Vector3.one;

        //更新内容
        tempGo.GetComponent<ChatItemUI>().UpdateConent(item.content);
        tempGo.GetComponent<ChatItemUI>().UpdateUsername(item.username);

        isAddMessage = true;
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

        tempGo.GetComponent<ChatItemUI>().UpdateConent(item.content);
        tempGo.GetComponent<ChatItemUI>().UpdateUsername(item.username);

        isAddMessage = true;
        FitScreen(tempGo);  //使物体适应屏幕

        ChatManager.Instance.itemUIList.Add(tempGo.GetComponent<ChatItemUI>());
        Clear();
    }

    void FitScreen(GameObject tempGo)
    {
        //适应聊天框
        Text tempChatText = tempGo.transform.Find("content").GetComponent<Text>();
        if (tempChatText.preferredWidth + 20.0f <= 60.0f)  //不足单行长度
        {
            tempGo.GetComponent<RectTransform>().sizeDelta = new Vector2(60.0f, tempChatText.preferredWidth + 10.0f * 2);
        }
        else if (tempChatText.preferredWidth + 20.0f > tempChatText.rectTransform.sizeDelta.x)  //超过单行长度
        {
            tempGo.GetComponent<RectTransform>().sizeDelta = new Vector2(tempChatText.rectTransform.sizeDelta.x + 20.0f, tempChatText.preferredHeight + 20.0f);
        }
        else  //让文字自适应聊天框
        {
            tempGo.GetComponent<RectTransform>().sizeDelta = new Vector2(tempChatText.preferredWidth + 20.0f, tempChatText.preferredHeight + 20.0f);
        }

        tempChatText.SetVerticesDirty();  //???作用未知
        tempGo.GetComponent<RectTransform>().anchoredPosition = new Vector3(-10.0f, -chatHeight);
        chatHeight += tempChatText.GetComponent<RectTransform>().sizeDelta.y + 20.0f + iconHeight + 10.0f;  //增加chatHeight高度，包括icon高度和间隔
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
        }
        inputContent.text = "";
    }
}
