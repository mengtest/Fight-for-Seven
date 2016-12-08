using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameHallController : MonoBehaviour
{
    private static GameHallController instance;
    public static GameHallController Instance { get { return instance; } }

    public GameObject[] gridList;  // 房间格子
    private const int gridCount = 8;  // 房间数量

    private List<GameHallModel> waitingList = new List<GameHallModel>();
    private Dictionary<int , GameHallModel> waitingDict = new Dictionary<int , GameHallModel>();

    void Awake()
    {
        instance = this;

        Load();

        FlushList();
    }

    // 模拟从服务器获取信息
    void Load()
    {
        GameHallModel model1 = new GameHallModel(1000, 6000, "我是第一个玩家");
        GameHallModel model2 = new GameHallModel(1001, 6001, "我是第二个玩家");

        waitingList.Add(model1);
        waitingList.Add(model2);
        waitingDict.Add(model1.roomId, model1);
        waitingDict.Add(model2.roomId, model2);
    }

    void Update()
    {
        // 模拟有人进入房间
        if (Input.GetKeyDown(KeyCode.F3))
        {
            PlayerEnter(1000, 6001, "我是测试人员一号");
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            PlayerEnter(1001, 6000, "我是测试人员二号");
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            FlushList();
        }
    }

    // 玩家进入房间，此时房间至少有一人
    void PlayerEnter(int roomId, int playerBIndex, string playerBName)
    {
        GameHallModel model;
        waitingDict.TryGetValue(roomId, out model);
        if(model == null)
        {
            // 错误
            return;
        }
        else if (model.isFull)
        {
            // 房间已满， 什么都不做
            return;
        }
        else
        {
            model.PlayerEnter(playerBIndex, playerBName);
        }
    }

    public void FlushList()
    {
        int count = 0;
        foreach (var model in waitingList)
        {
            if(count >= 8)
            {
                return;  // 每页只显示最多8个房间
            }
            else
            {
                // 更新界面
                GameObject gridGo = gridList[count % gridCount];
                gridGo.SetActive(true);
                gridGo.GetComponent<GameHallModelView>().UpdateHall(model);

                
            }
            ++count;
        }

        for (int i = count; i < gridCount; ++i)  // 不足8个房间其余的需要隐藏
        {
            gridList[i % gridCount].SetActive(false);
        }
    }
}
