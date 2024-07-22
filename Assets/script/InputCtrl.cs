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
                //�Ƿ���UI��
                //if (EventSystem.current.IsPointerOverGameObject())
                //{
                //    return;
                //}
                //��������߼�
                int layer = obj.layer;
                if (layer != LayerMask.NameToLayer("Node"))
                {
                    return;
                }
                //�ж��Ƿ��ǽڵ�
                CellNode cellNode = obj.GetComponent<CellNode>();
                if(cellNode != null)
                {
                    //״̬1
                    if (status == Status.SetSelect)
                    {//���е�����ѡ�����ڵ�->�л�״̬
                        if(cellNode.curType == NodeType.positiveNode && (!cellNode.isLock))
                        {
                            selectNode = cellNode;
                            cellNode.SetSelected(SelectedType.selected);
                            SetStatus(Status.SetOptions);

                            // ��һ��
                           

                            DOLeanTweenFrist();

                        }
                    } //״̬2
                    else if (status == Status.SetOptions)
                    {//���е�����ͬһ���ڵ�
                        if(cellNode.GetInstanceID() == selectNode.GetInstanceID()){
                            cellNode.SetSelected(SelectedType.splitSelected);
                            SetStatus(Status.SetTarget);

                            //����
                          

                            DOLeanTweenSecond();
                        }
                        else
                        {
                            //����ͬһ���ڵ� ���ж��Ƿ��ܵ�
                            targetNode = cellNode;
                            if (selectNode.IsConnected(targetNode))
                            {
                                selectNode.Crash(targetNode);
                                SetStatus(Status.SetSelect);
                            }
                        }
                    }else if(status == Status.SetTarget)
                    {//�����ε���������ڵ�
                        if ((cellNode.GetInstanceID() != selectNode.GetInstanceID()))
                        {
                            targetNode = cellNode;
                            //�ж��Ƿ�Χ��
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
