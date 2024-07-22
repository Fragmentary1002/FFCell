using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellNode : MonoBehaviour
{
    public enum Status
    {
        Selected,
        UnSelected
    }
    //
    public int initValue;
    public NodeType lastType;
    public int curValue;
    public static int idCnt;
    public int id;
    public List<CellNode> connectedNodes = new List<CellNode>();
    public Vector3 initPos = Vector3.zero;
    /// <summary>
    ///  没有使用该字段
    /// </summary>
    public NodeType initType = NodeType.nullNode;


    public NodeType curType = NodeType.negativeNode;
    public SelectedType selectedType = SelectedType.unSelected;
    public bool isCrucial = false;
    public bool isLock = false;
    public NodeUI nodeUI;
    public CellNode localCellNode;
    public GameObject crucialBg;
    public GameObject normalBg;



    private void Awake()
    {
        idCnt = 0;
      
    }
    void Start()
    {
        nodeUI = GetComponent<NodeUI>();
        idCnt++;
        id = idCnt;
        EventCenter.GetInstance().AddEventListener("UnlockAll", Unlock);
        localCellNode = GetComponent<CellNode>();
        nodeUI.Spawn(localCellNode);
        //到老大节点注册
        FatherNode.Instance.allNodes.Add(localCellNode);
        if (isCrucial)
        {
            FatherNode.Instance.allCrucialNodes.Add(localCellNode);
        }

        //init type;
        SetSelected(SelectedType.unSelected);

        SetValue(initValue);

        //链接
        if (isCrucial)
        {
            GameObject obj = Instantiate(crucialBg);
            obj.transform.position = transform.position;
        }
        else
        {
            GameObject obj = Instantiate(normalBg);
            obj.transform.position = transform.position;
        }


    }
    void Update()
    {

    }
    public void SetValue(int value)
    {
        curValue = value;
        nodeUI.ValueChange(GetComponent<CellNode>(), curValue);
        UpadateType();

    }
    public void UpadateType()
    {
        lastType = curType;
        //TODO:some logic
        if (curValue > 0)
        {
            //nodeUI.TypeTurn(localCellNode, NodeType.positiveNode);
            
            curType = NodeType.positiveNode;

        } else if (curValue == 0)
        {
            //nodeUI.TypeTurn(localCellNode, NodeType.nullNode);
            curType = NodeType.nullNode;
        }
        else
        {
            //nodeUI.TypeTurn(localCellNode, NodeType.negativeNode);
            curType = NodeType.negativeNode;
        }
    }
    public void Crash(CellNode cellNode)
    {
        //判断cellNode是否相邻（冗余
        if (!connectedNodes.Contains(cellNode))
        {
            return;
        }
        //判断当前Node是否可控

        cellNode.SetValue(curValue + cellNode.curValue);
        SetValue(0);
        // 更新锁定
        this.isLock = false;
        cellNode.isLock = true;
        

    
        nodeUI.Crash(GetComponent<CellNode>(), cellNode);

        //nodeUI.LockTurn(cellNode, cellNode.isLock);

    }
    public void SplitAndCrash(CellNode cellNode)
    {
        //判断相邻(冗余
        if (!connectedNodes.Contains(cellNode))
        {
            return;
        }

        int tmp = (int)Mathf.Ceil((float)curValue / 2.0f);
        SetValue(curValue - tmp);
        cellNode.SetValue(cellNode.curValue + tmp);
        // 更新锁定
        localCellNode.isLock = false;
        cellNode.isLock = true;
        //nodeUI.LockTurn(cellNode, cellNode.isLock);

        nodeUI.SplitAndCrash(localCellNode, cellNode);
    }
    public void SetSelected(SelectedType selType)
    {
        selectedType = selType;
        nodeUI.SetSelected(GetComponent<CellNode>(), selType);
    }

    public bool IsConnected(CellNode node2)
    {
        return connectedNodes.Contains(node2);
    }
    public void Unlock()
    {
        isLock = false;
        if (localCellNode != null)
        {
            nodeUI.LockTurn(localCellNode, localCellNode.isLock);
        }
    }
    public int GetValue()
    {
        return curValue;
    }
    private void OnDrawGizmos()
    {
        if (connectedNodes != null && connectedNodes.Count != 0)
        {
           
            Gizmos.color = Color.red;
            for(int i = 0; i < connectedNodes.Count; i++)
            {
                if (connectedNodes[i] != null)
                {
                    Gizmos.DrawLine(transform.position, connectedNodes[i].transform.position);
                    Vector3 v = (connectedNodes[i].transform.position - transform.position).normalized;
                    v = new Vector3(v.x * 0.1f, v.y * 0.1f, v.z * 0.1f);
                    Gizmos.DrawSphere(transform.position + v, 0.02f);
                }
                else
                {
                    Debug.LogError("CellNode : OnDrawGizmos ERROR  connectedNodes[i] != null");
                }
            }
        }
    }
}
