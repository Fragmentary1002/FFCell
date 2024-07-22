using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowCtrl : MonoBehaviour
{
    public enum Status
    {
        Start,
        PlayerRound,
        EnemyRound,
        End,
        Win,
        Lose
    }
    public int roundCnt = 0;
    public Status status = Status.Start;
    public GameObject window;
    public Canvas canvas;
    void Start()
    {
        EventCenter.GetInstance().AddEventListener("CrashComplete", CheckBoth);
        //UI Button事件
        EventCenter.GetInstance().AddEventListener("RoundEnd", ToEnemyRound);
        //UI完成敌人操作的表现
        EventCenter.GetInstance().AddEventListener("EnemyRoundEnd", ToEnd);
    }

    void Update()
    {
        if(status == Status.Start)
        {
            EventCenter.GetInstance().EventTrigger("UnlockAll");
            status = Status.PlayerRound;
        }else if (status == Status.PlayerRound)
        {
            if(InputCtrl.instance.canCtrl == false)
            {
                InputCtrl.instance.SetCanCtrl(true);
            }
        }else if(status == Status.EnemyRound)
        {

        }else if(status == Status.End)
        {

        }
    }
    public void ToEnemyRound()
    {
        if(status == Status.PlayerRound)
        {
            status = Status.EnemyRound;
            //不准操作
            InputCtrl.instance.SetCanCtrl(false);
            //负数节点X2
            List<CellNode> negNodes = FatherNode.Instance.GetAllNegNode();
            for (int i = 0; i < negNodes.Count; i++)
            {
                negNodes[i].SetValue(negNodes[i].curValue * 2);
            }
            StartCoroutine(DelayCall("EnemyRoundEnd"));
        }
    }
    IEnumerator DelayCall(string str)
    {
        //yield return new WaitForSeconds(0f);
        EventCenter.GetInstance().EventTrigger(str);
        yield return null;
    }

    public void CheckBoth()
    {
        if(status == Status.PlayerRound)
        {
            //TODO logic CheckWin() CheckLose()
            if (CheckWin())
            {
                status = Status.Win;
                EventCenter.GetInstance().EventTrigger("PlayerWin");
                //GameObject obj = Instantiate(window);
                //obj.transform.SetParent(transform);
                //window.SetActive(true);
                Debug.Log("玩家胜利");

            }
            else if (CheckLose())
            {
                status = Status.Lose;
                EventCenter.GetInstance().EventTrigger("PlayerLose");
            }
        }
    }
    public bool CheckWin()
    {
        //FatherNode.Instance.IsWin();
        return FatherNode.Instance.IsWin(); ;
    }
    
    public bool CheckLose()
    {
        List<CellNode> allNodes = FatherNode.Instance.allNodes;
        for(int i = 0; i < allNodes.Count; i++)
        {
            //if(allNodes[i].isLock)
        }
        return false;
    }
    public void ToEnd()
    {
        if(status == Status.EnemyRound)
        {
            status = Status.End;
            roundCnt++;
            status = Status.Start;
        }
    }
    public void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener("CrashComplete", CheckBoth);
        //UI Button事件
        EventCenter.GetInstance().RemoveEventListener("RoundEnd", ToEnemyRound);
        //UI完成敌人操作的表现
        EventCenter.GetInstance().RemoveEventListener("EnemyRoundEnd", ToEnd);
    }
}
