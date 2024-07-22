using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonHandler : MonoBehaviour
{
    public Button endButton; // �� Unity �༭���н���ť�����ϵ�����ֶ�
    NodeType nodeType = NodeType.nullNode;

    void Start()
    {
        if (endButton != null)
        {
            endButton.onClick.AddListener(OnEndButtonClick);
        }
    }

    void OnEndButtonClick()
    {
        // �����ǰ�ť���ʱҪִ�еĲ���
        Debug.Log("End Button Clicked!");
        // ���磬�˳���Ϸ
        //Application.Quit();
       
    }
}
