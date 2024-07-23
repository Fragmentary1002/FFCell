using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FatherNode : MonoBehaviour
{
    public static FatherNode Instance;
    public List<CellNode> allNodes;
    public List<CellNode> allCrucialNodes;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        allNodes = new List<CellNode>();
        allCrucialNodes = new List<CellNode>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsWin()
    {
        bool isWin = true;
        for(int i = 0; i < allCrucialNodes.Count; i++)
        {
            if(allCrucialNodes[i].curValue < 0)
            {
                isWin = false;
                break;
            }
        }
        return isWin;
    }
    public List<CellNode> GetAllNegNode()
    {
        List<CellNode> returnList = new List<CellNode>();
        for(int i = 0; i < allNodes.Count; i++)
        {
            if(allNodes[i].curType == NodeType.negativeNode)
            {
                returnList.Add(allNodes[i]);
            }
        }
        return returnList;
    }


}
