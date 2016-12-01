using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RankUI : MonoBehaviour
{
    public Sprite unselectSprite;
    public Sprite selectSprite;
    public Image competitionImage;
    public Image wealthImage;
    public Image charmImage;
    public Button leftBtn;
    public Button rightBtn;
    public GameObject rankPanel;
    public GameObject girlImage;
    public GameObject leftBtnGo;
    public GameObject rightBtnGo;

    private RankType type;
    private const int pageLength = 10;
    private int from = 0;
    private int to = pageLength;

    public void OnCompetitionBtnClick()
    {
        type = RankType.Competition;
        SetState();
        //改变样式
        competitionImage.sprite = selectSprite;
        wealthImage.sprite = unselectSprite;
        charmImage.sprite = unselectSprite;

        if (to < RankManager.Instance.competitionLength)  //榜上数量较多
        {
            rightBtnGo.SetActive(true);
        }
        else  //少于10人则按少的计数
        {
            to = RankManager.Instance.competitionLength;
            rightBtnGo.SetActive(false);
        }

        RankManager.Instance.LoadCompetition(from,to);
    }

    public void OnWealthBtnClick()
    {
        type = RankType.Wealth;
        SetState();
        //改变样式
        competitionImage.sprite = unselectSprite;
        wealthImage.sprite = selectSprite;
        charmImage.sprite = unselectSprite;

        if (to < RankManager.Instance.wealthLength)  //榜上数量较多
        {
            rightBtnGo.SetActive(true);
        }
        else  //少于10人则按少的计数
        {
            to = RankManager.Instance.wealthLength;
            rightBtnGo.SetActive(false);
        }

        RankManager.Instance.LoadWealth(from, to);
    }

    public void OnCharmBtnClick()
    {
        type = RankType.Charm;
        SetState();
        //改变样式
        competitionImage.sprite = unselectSprite;
        wealthImage.sprite = unselectSprite;
        charmImage.sprite = selectSprite;

        if (to < RankManager.Instance.charmLength)  //榜上数量较多
        {
            rightBtnGo.SetActive(true);
        }
        else  //少于10人则按少的计数
        {
            to = RankManager.Instance.charmLength;
            rightBtnGo.SetActive(false);
        }

        RankManager.Instance.LoadCharm(from, to);
    }

    void SetState()
    {
        from = 0;
        to = pageLength;
        rankPanel.SetActive(true);
        leftBtnGo.SetActive(false);
        rightBtnGo.SetActive(false);
        girlImage.SetActive(false);
    }

    public void OnLeftBtnClick()  //排行榜按下左键
    {
        //此时右键肯定可以按下，左键则不一定
        rightBtnGo.SetActive(true);
        leftBtnGo.SetActive(true);

        to = from;  //从上次的开始作为结束
        from = to - pageLength;
        if (from == 0)  //判断是否等于0
        {
            leftBtnGo.SetActive(false);
        }
        switch (type)
        {
            case RankType.Competition:
                RankManager.Instance.LoadCompetition(from, to);
                break;
            case RankType.Wealth:
                RankManager.Instance.LoadWealth(from, to);
                break;
            case RankType.Charm:
                RankManager.Instance.LoadCharm(from, to);
                break;
            default:
                break;
        }
    }

    public void OnRightBtnClick()  //排行榜按下右键
    {
        //此时左键肯定可以按，右键不一定
        leftBtnGo.SetActive(true);
        rightBtnGo.SetActive(true);

        from = to;  //从上次末尾开始
        to = to + pageLength;
        switch (type)
        {
            case RankType.Competition:
                //判断是否超出榜上人数
                if (to >= RankManager.Instance.competitionLength)  //超出则不能再按右键
                {
                    to = RankManager.Instance.competitionLength;
                    rightBtnGo.SetActive(false);
                }
                RankManager.Instance.LoadCompetition(from, to);
                break;
            case RankType.Wealth:
                if (to >= RankManager.Instance.wealthLength)
                {
                    to = RankManager.Instance.wealthLength;
                    rightBtnGo.SetActive(false);
                }
                RankManager.Instance.LoadCompetition(from, to);
                break;
            case RankType.Charm:
                if (to >= RankManager.Instance.charmLength)
                {
                    to = RankManager.Instance.charmLength;
                    rightBtnGo.SetActive(false);
                }                
                RankManager.Instance.LoadCharm(from, to);
                break;
            default:
                break;
        }
    }
}
