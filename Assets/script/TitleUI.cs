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
        // ������ť����¼�
        StartBut.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(FirstMission, LoadSceneMode.Single);
        });

        // ���ð�ť����¼�
        SetBtn.onClick.AddListener(() =>
        {
          
            setWnd.SetActive(!setWnd.activeSelf);
        });

        // �˳���ť����¼�
        Exit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        // ������������������߼�
    }
}
