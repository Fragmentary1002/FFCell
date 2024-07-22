using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackUI : MonoBehaviour
{
    public Button backButton;
    public GameObject thisWnd;

    private void Start()
    {
        // 注册返回按钮点击事件
        backButton.onClick.AddListener(OnBackButtonClick);
        thisWnd=this.gameObject;
    }

    private void OnBackButtonClick()
    {
        // 关闭 ThisWnd 窗口
        thisWnd.SetActive(false);
    }
}
