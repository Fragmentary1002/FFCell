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
     
        // 下一回合按钮点击事件
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
        // 可以在这里添加其他逻辑
    }


    private void LoadNextScene()
    {
        // 获取当前场景的索引
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 计算下一个场景的索引
        int nextSceneIndex = currentSceneIndex + 1;

        // 检查是否有下一个场景
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // 加载下一个场景
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        }
        else
        {
            // 如果没有下一个场景，打印调试信息或执行其他逻辑
            Debug.Log("This is the last scene. No more scenes to load.");
        }
    }

    public void StrAppend()
    {
        txtRetryCnt.text = "重试" + GameUIConfig.retryCnt.ToString()+"次";
    }

    public void OpenWinwnd()
    {
        winWnd?.SetActive(true);
    }
}
