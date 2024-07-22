using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputCtrl : MonoBehaviour
{
    public enum Status
    {
        SetSelect,
        SetOptions,
        SetTarget
    }
    public static InputCtrl instance;
    public bool canCtrl = true;
    public Status status = Status.SetSelect;
    public CellNode selectNode;
    public CellNode targetNode;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //EventCenter.GetInstance().AddEventListener<bool>("CrashSet", SetCrash);
        //EventCenter.GetInstance().EventTrigger("CrashSet",true);
    }

    void Update()
    {
        if (!canCtrl)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2d, Vector2.zero);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hitInfo;
            

            if (hit.collider!=null)
            {
                GameObject obj = hit.collider.gameObject;
                //是否在UI上
                //if (EventSystem.current.IsPointerOverGameObject())
                //{
                //    return;
                //}
                //处理具体逻辑
                int layer = obj.layer;
                if (layer != LayerMask.NameToLayer("Node"))
                {
                    return;
                }
                //判断是否是节点
                CellNode cellNode = obj.GetComponent<CellNode>();
                if(cellNode != null)
                {
                    //状态1
                    if (status == Status.SetSelect)
                    {//点中的是能选的正节点->切换状态
                        if(cellNode.curType == NodeType.positiveNode && (!cellNode.isLock))
                        {
                            selectNode = cellNode;
                            cellNode.SetSelected(SelectedType.selected);
                            SetStatus(Status.SetOptions);

                            // 第一次
                           

                            DOLeanTweenFrist();

                        }
                    } //状态2
                    else if (status == Status.SetOptions)
                    {//点中的是能同一个节点
                        if(cellNode.GetInstanceID() == selectNode.GetInstanceID()){
                            cellNode.SetSelected(SelectedType.splitSelected);
                            SetStatus(Status.SetTarget);

                            //分裂
                          

                            DOLeanTweenSecond();
                        }
                        else
                        {
                            //不是同一个节点 则判断是否能点
                            targetNode = cellNode;
                            if (selectNode.IsConnected(targetNode))
                            {
                                selectNode.Crash(targetNode);
                                SetStatus(Status.SetSelect);
                            }
                        }
                    }else if(status == Status.SetTarget)
                    {//第三次点中了这个节点
                        if ((cellNode.GetInstanceID() != selectNode.GetInstanceID()))
                        {
                            targetNode = cellNode;
                            //判断是否范围内
                            if (!selectNode.IsConnected(targetNode))
                            {
                                return;
                            }
                            selectNode.SplitAndCrash(targetNode);
                            SetStatus(Status.SetSelect);
                            
                        }
                    }
                    else
                    {
                        Debug.Log("inputCtrl Wrong");
                    }
                }   
            }
        }else if(Input.GetMouseButtonDown(1))
        {
            SetStatus(Status.SetSelect);
        }
    }
    public void SetCanCtrl(bool can)
    {
        canCtrl = can;
    }
    public void SetStatus(Status sta)
    {
        status = sta;
        if(sta == Status.SetSelect)
        {
            if (selectNode != null) 
            {
                selectNode.SetSelected(SelectedType.unSelected);
            }
            if (targetNode != null)
            {
                targetNode.SetSelected(SelectedType.unSelected);
            }
            selectNode = null;
            targetNode = null;
        }
    }


    public void DOLeanTweenFrist()
    {
        MusicMgr.GetInstance().PlaySound("first_click", false);
        float scale = 1.1f;
        float duration = 0.2f;
        float half = duration / 2;
        Vector3 vec3 = new Vector3(scale, scale, scale);
        LeanTween.scale(selectNode.gameObject, vec3, half).setOnComplete(() =>
        {
            LeanTween.scale(selectNode.gameObject, Vector3.one, half);
        });
        
    }


    public void DOLeanTweenSecond()
    {
        MusicMgr.GetInstance().PlaySound("second_click", false);
        float scale = 1.1f;
        float duration = 0.2f;
        float half = duration / 2;
        LeanTween.scaleX(selectNode.gameObject, scale, half).setOnComplete(() =>
        {
            LeanTween.scaleX(selectNode.gameObject, 1, half);
        });
    }
}
