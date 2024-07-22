using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    public GameObject go;
    public Button myButton;
    public NodeUI nodeUI;
    public int idx = 0;

    private CellNode cellNode;


    public void Start()
    {
        go=this.gameObject;
        cellNode = go.GetComponent<CellNode>();
        nodeUI=go.GetComponent<NodeUI>();
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogWarning("Button not assigned in the inspector.");
        }
    }

    private void OnButtonClick()
    {
        Debug.Log("OnButtonClick");
        // 调用 SetSelected 方法，假设你有一个 SelectedType 类型的值
        idx++;
        idx /=3;
        nodeUI.SetSelected(cellNode, (SelectedType)idx); // 你可以更改这个值以测试不同的状态
    }
}