using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public Button StartBut;
    public Button SetBtn;
    public Button Exit;
    public GameObject setWnd;
    public int FirstMission = 1;
    public int MissionSelect = 2;

    void Start()
    {
        // 启动按钮点击事件
        StartBut.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(FirstMission, LoadSceneMode.Single);
        });

        // 设置按钮点击事件
        SetBtn.onClick.AddListener(() =>
        {
          
            setWnd.SetActive(!setWnd.activeSelf);
        });

        // 退出按钮点击事件
        Exit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        // 可以在这里添加其他逻辑
    }
}
