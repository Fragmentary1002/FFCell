using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text;

public class WinWndUI : MonoBehaviour
{
    public Image image8;                // Image component
    public TextMeshProUGUI cntTxt;      // TextMeshProUGUI component for displaying text
    public Button LoadNextSceneBtn;                  // Button component
    public TextMeshProUGUI txtRetryCnt;

    private void Start()
    {
        // 注册按钮点击事件
        LoadNextSceneBtn.onClick.AddListener(OnOr0ButtonClick);

        // 初始时隐藏窗口

    }

    private void OnEnable()
    {
        StrAppend();
    }
    private void OnOr0ButtonClick()
    {
        // 打印调试信息
        Debug.Log("Or0 Button Clicked");

        // 隐藏当前窗口
        //   this.gameObject.SetActive(false);

        GameUIConfig.retryCnt = 0;
        // 加载下一个场景
        LoadNextScene();

    }
    private void OnDestroy()
    {
        this.gameObject.SetActive(false);

    }
    private void LoadNextScene()
    {
        Debug.Log("LoadNextSceneBtn");
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
        txtRetryCnt.text = "尝试次数：" + GameUIConfig.retryCnt.ToString();
    }
}
