using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHallModelView : MonoBehaviour
{
    public Image playerAHeader;
    public Image playerBHeader;
    public Text roomIdText;
    public Text playerANameText;
    public Text playerBNameText;
    public Button enterBtn;

    public GameHallModel model;

    public void UpdateHall(GameHallModel model)
    {
        this.model = model;
        if (model.isFull)  // 两人都显示
        {
            playerBHeader.enabled = true;  // 此时玩家B需要显示
            playerBNameText.enabled = true;

            roomIdText.text = model.roomId.ToString();
            playerAHeader.sprite = Resources.Load("images/" + model.playerAHeaderIndex, new Sprite().GetType()) as Sprite;
            playerBHeader.sprite = Resources.Load("images/" + model.playerBHeaderIndex, new Sprite().GetType()) as Sprite;
            playerANameText.text = model.playerAName;
            playerBNameText.text = model.playerBName;

            enterBtn.interactable = false;
        }
        else  // 房间没满，只需要显示玩家A
        {
            roomIdText.text = model.roomId.ToString();
            playerAHeader.sprite = Resources.Load("images/" + model.playerAHeaderIndex, new Sprite().GetType()) as Sprite;
            playerBHeader.enabled = false;  // 不显示玩家A
            playerANameText.text = model.playerAName;
            playerBNameText.enabled = false;

            enterBtn.interactable = true;
        }
    }
}
