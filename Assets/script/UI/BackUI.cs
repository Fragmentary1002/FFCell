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
        // ע�᷵�ذ�ť����¼�
        backButton.onClick.AddListener(OnBackButtonClick);
        thisWnd=this.gameObject;
    }

    private void OnBackButtonClick()
    {
        // �ر� ThisWnd ����
        thisWnd.SetActive(false);
    }
}
