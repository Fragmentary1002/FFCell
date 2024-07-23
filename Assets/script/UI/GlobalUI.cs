using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text;

public class GlobalUI : MonoBehaviour
{
    public Button instruct;
    public Button retry;
    public Button seting;
    public Button back;
    public Button nextRound;
    public TextMeshProUGUI txtRetryCnt;
    public GameObject winWnd;

    void Start()
    {
     
        // ��һ�غϰ�ť����¼�
        nextRound?.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger("RoundEnd");
        });

        retry?.onClick.AddListener(() =>
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index, LoadSceneMode.Single);
            GameUIConfig.retryCnt++;
         
        });

    
        seting?.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger("OpenSetting");
        });
        back?.onClick.AddListener(() =>
        {
           
        });
        EventCenter.GetInstance().AddEventListener("PlayerWin", OpenWinwnd);
    }
    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener("PlayerWin", OpenWinwnd);
    }
    private void OnEnable()
    {
        StrAppend();
    }
    // Update is called once per frame
    void Update()
    {
        // ������������������߼�
    }


    private void LoadNextScene()
    {
        // ��ȡ��ǰ����������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ������һ������������
        int nextSceneIndex = currentSceneIndex + 1;

        // ����Ƿ�����һ������
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // ������һ������
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        }
        else
        {
            // ���û����һ����������ӡ������Ϣ��ִ�������߼�
            Debug.Log("This is the last scene. No more scenes to load.");
        }
    }

    public void StrAppend()
    {
        txtRetryCnt.text = "����" + GameUIConfig.retryCnt.ToString()+"��";
    }

    public void OpenWinwnd()
    {
        winWnd?.SetActive(true);
    }
}
