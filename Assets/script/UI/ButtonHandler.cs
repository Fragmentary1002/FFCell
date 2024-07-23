using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonHandler : MonoBehaviour
{
    public Button endButton; // 在 Unity 编辑器中将按钮对象拖到这个字段
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
        // 这里是按钮点击时要执行的操作
        Debug.Log("End Button Clicked!");
        // 例如，退出游戏
        //Application.Quit();
       
    }
}
