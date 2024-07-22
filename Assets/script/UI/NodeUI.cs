using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NodeUI : MonoBehaviour
{
    public TextMeshPro textMeshPro;

    public float speed=0.5f;

    public CellNode cellNode;

    public int initValue;

    private void Start()
    {
        CanvasForValue.instance.AddTextToNode(GetComponent<CellNode>());
        this.cellNode=this.GetComponent<CellNode>();
        this.initValue =this.cellNode.initValue;
        EventCenter.GetInstance().AddEventListener("UnlockAll", Boom);

        //TODO:some logic
        if (initValue > 0)
        {
            this.TypeTurn(cellNode, NodeType.positiveNode);
           
        }
        else if (initValue == 0)
        {

            this.TypeTurn(cellNode, NodeType.nullNode);
          
        }
        else
        {
            this.TypeTurn(cellNode, NodeType.negativeNode);
        }

      
    }

    //移动
    public void Crash(CellNode node1, CellNode node2)
    {
        Debug.Log("Crash method called with node1: " + node1 + ", node2: " + node2);
        // Method implementation
        Debug.Log("Crash method finished");

        


        PoolMgr.GetInstance().GetObj("Prefabs/MovePre", (o) =>
        {

            Debug.Log($"========================{this.cellNode.curType}===========================");
            this.TypeTurn(this.cellNode, this.cellNode.curType);

            SpriteTransition spriteTransition = o.GetComponent<SpriteTransition>();

            spriteTransition.StartAnim(node1.transform.position, node2.transform.position, () =>
            {
                EventCenter.GetInstance().EventTrigger("CrashComplete");
                this.TypeTurn(node2, node2.curType);
               
                this.LockTurn(node2,node2.isLock);


            });
           // StartCoroutine(DelayCall("CrashComplete"));
        });

    

    }

    

    //分裂移动
    public void SplitAndCrash(CellNode node1, CellNode node2)
    {
        Debug.Log("SplitAndCrash method called with node1: " + node1 + ", node2: " + node2);
        // Method implementation
        Debug.Log("SplitAndCrash method finished");





        PoolMgr.GetInstance().GetObj("Prefabs/MovePre", (o) =>
        {

         
            this.TypeTurn(this.cellNode, this.cellNode.curType);

            SpriteTransition spriteTransition = o.GetComponent<SpriteTransition>();

            spriteTransition.StartAnim(node1.transform.position, node2.transform.position, () =>
            {
                EventCenter.GetInstance().EventTrigger("CrashComplete");
                this.TypeTurn(node2, node2.curType);


                this.LockTurn(node2, node2.isLock);



            });
            // StartCoroutine(DelayCall("CrashComplete"));
        });



    }

    public void LockTurn(CellNode cellNode, bool islock)
    {
        Debug.Log($"============================{cellNode.name}==========");


        Transform[] trans = cellNode.GetComponentsInChildren<Transform>(true);

        Debug.Log(trans);
        if (trans == null) {
            Debug.Log("tran null!!!!!!!!!!!!!!");
            return;
        }
        foreach (Transform child in trans)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                if (islock)
                {
                   if (cellNode.curType == NodeType.negativeNode)
                    {
                        return;
                    }

                    Color color = spriteRenderer.color;
                    color.a = 0.7f; // 减小透明度，例如设为0.7
                    spriteRenderer.color = color;
                }
                else
                {
                    Color color = spriteRenderer.color;
                    color.a = 1.0f; // 恢复透明度
                    spriteRenderer.color = color;
                }
            }
            else
            {
                Debug.LogWarning("SpriteRenderer component not found on cellNode");
            }

        }



       

        Debug.Log("LockTurn method finished");
    }


    public void Spawn(CellNode cellNode)
    {
        Debug.Log("Spawn method called with cellNode: " + cellNode);
        // Method implementation
        Debug.Log("Spawn method finished");


    }

    public void TypeTurn(CellNode cellNode, NodeType nodeType)
    {

        if (cellNode == null)
        {
            Debug.LogError("cellNode is null");
            return;
        }

        Debug.Log("==================TypeTurn method called with nodeType: " + nodeType);

        string path;
        switch (nodeType)
        {
            case NodeType.positiveNode:
                Debug.Log("Processing positiveNode");
                path = "PositiveNodePath"; // 子节点路径
                if(cellNode.lastType == NodeType.negativeNode)
                {
                    DOsomething( cellNode);
                }
                break;

            case NodeType.negativeNode:
                Debug.Log("Processing negativeNode");
                path = "NegativeNodePath"; // 子节点路径
                break;
            case NodeType.nullNode:
                Debug.Log("Processing nullNode");
                path = "NullNodePath"; // 子节点路径
                break;
            default:
                Debug.LogError("Unknown NodeType");
                return;
        }


        Debug.Log("Path set to: " + path);


        // 获取所有子对象，不包括自身


        Transform[] childTransforms = cellNode.GetComponentsInChildren<Transform>(true);

        if (childTransforms == null)
        {
            Debug.LogError("childTransforms is null");

        }

        foreach (Transform child in childTransforms)
        {
            // 排除 cellNode 自身
            if (child == cellNode.transform)
            {
                continue;
            }

            // 处理子对象
            if (child.gameObject.name == path)
            {
                child.gameObject.SetActive(true); // 显示匹配的子节点
            }
            else
            {
                child.gameObject.SetActive(false); // 隐藏不匹配的子节点
            }
        }

        return;
        //StartCoroutine(ImgTurn(cellNode, path));
    }


    // 弹出窗口  分裂 


    public void SetSelected(CellNode cellNode, SelectedType selectedType)
    {
        Debug.Log("SetSelected method called with cellNode: " + cellNode + ", selectedType: " + selectedType);

        List<CellNode> connectedNodes = new List<CellNode>();
        if (cellNode.connectedNodes != null) connectedNodes = cellNode.connectedNodes;

        // Ensure the connectedNodes list is initialized
        if (connectedNodes == null)
        {
            Debug.LogWarning("connectedNodes not found on cellNode");
            return;
        }


        // 获取所有子对象，不包括自身



        // Handle the sprite replacement for all connected nodes (children
        ///分发 可连接的所有节点 状态  的childNodeArr
        foreach (var node in connectedNodes)
        {
            ChildNode[] childNodeArr = cellNode.GetComponentsInChildren<ChildNode>(true);


            if (childNodeArr == null)
            {
                Debug.LogError("childTransforms is null");
                return;
            }


            //遍历arr
            foreach (ChildNode childNode in childNodeArr)
            {
                if (childNode != null)
                {
                    childNode.UpdateSprite(selectedType);
                }
                else
                {
                    Debug.LogWarning("ChildNode component not found on connected node");
                }
            }
        }
    }

    public bool ValueChange(CellNode cellNode,int val) {

        if (cellNode == null) return false;


       CanvasForValue.instance.UpdateCanvasText(cellNode);
       

        return true;

    }

    public void DOsomething(CellNode cellNode)
    {
        // sound
        Debug.Log("DOsomething");
        MusicMgr.GetInstance().PlaySound("change", false);

        // shake rotation
        LeanTween.rotate(cellNode.gameObject, new Vector3(0, 0, 10), 0.2f)
                 .setEase(LeanTweenType.easeShake);

        float scale = 1.1f;
        float duration = 0.2f;
        float half = duration / 2;
        Vector3 vec3 = new Vector3(scale, scale, scale);
        LeanTween.scale(cellNode.gameObject, vec3, half).setOnComplete(() =>
        {
            LeanTween.scale(cellNode.gameObject, Vector3.one, half);
        });
    }

    public void Boom()
    {
        if(cellNode.curType != NodeType.positiveNode)
        {
            return;
        }
        float scale = 1.3f;
        float duration = 0.2f;
        float half = duration / 2;
        Vector3 vec3 = new Vector3(scale, scale, scale);
        LeanTween.scale(this.cellNode.gameObject, vec3, half).setOnComplete(() =>
        {
            LeanTween.scale(this.cellNode.gameObject, Vector3.one, half);
        });
    }

    public void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener("UnlockAll", Boom);
    }
}
