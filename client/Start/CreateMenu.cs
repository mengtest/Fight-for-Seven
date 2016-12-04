using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CreateMenu : MonoBehaviour
{
    private int selectIndex = -1;

    public Sprite unselectSprite;
    public Sprite selectSprite;
    public Image btnOne;
    public Image btnTwo;
    public Image btnThree;
    public Image btnFour;
    public InputField username;

    public void OnRoleOneBtnClick()
    {
        btnOne.sprite = selectSprite;
        btnTwo.sprite = unselectSprite;
        btnThree.sprite = unselectSprite;
        btnFour.sprite = unselectSprite;
        selectIndex = 1000;
    }

    public void OnRoleTwoBtnClick()
    {
        btnOne.sprite = unselectSprite;
        btnTwo.sprite = selectSprite;
        btnThree.sprite = unselectSprite;
        btnFour.sprite = unselectSprite;
        selectIndex = 1001;
    }

    public void OnRoleThreeBtnClick()
    {
        btnOne.sprite = unselectSprite;
        btnTwo.sprite = unselectSprite;
        btnThree.sprite = selectSprite;
        btnFour.sprite = unselectSprite;
        selectIndex = 1002;
    }

    public void OnRoleFourBtnClick()
    {
        btnOne.sprite = unselectSprite;
        btnTwo.sprite = unselectSprite;
        btnThree.sprite = unselectSprite;
        btnFour.sprite = selectSprite;
        selectIndex = 1003;
    }

    public void OnComfirmBtnClick()
    { 

        if (selectIndex == -1)
        {
            MessageManager.instance.ShowLog("请选择一个新角色");
        }
        else if(username.text.Length < 3 || username.text.Length > 10)
        {
            MessageManager.instance.ShowLog("名字不合法");
        }
        else
        {
            SocketModel createRequest = new SocketModel();
            createRequest.SetType(TypeProtocol.TYPE_CREATE_ROLE);
            createRequest.SetArea(AreaProtocol.Area_CreateRoleRequest);
            createRequest.SetCommand(0);
            List<string> message = new List<string>();
            message.Add(selectIndex.ToString());
            message.Add(username.text);
            createRequest.SetMessage(message);
            MainClient.Instance.SendMsg(createRequest);
        }
    }
}
