using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RankItemUI : MonoBehaviour
{
    public Text rankText;
    public Text usernameText;
    public Text desText;

	public void UpdateRank(string rank,string username,string des)
    {
        rankText.text = rank;
        usernameText.text = username;
        desText.text = des;
    }
}
