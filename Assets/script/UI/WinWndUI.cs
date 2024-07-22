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
        // ע�ᰴť����¼�
        LoadNextSceneBtn.onClick.AddListener(OnOr0ButtonClick);

        // ��ʼʱ���ش���

    }

    private void OnEnable()
    {
        StrAppend();
    }
    private void OnOr0ButtonClick()
    {
        // ��ӡ������Ϣ
        Debug.Log("Or0 Button Clicked");

        // ���ص�ǰ����
        //   this.gameObject.SetActive(false);

        GameUIConfig.retryCnt = 0;
        // ������һ������
        LoadNextScene();

    }
    private void OnDestroy()
    {
        this.gameObject.SetActive(false);

    }
    private void LoadNextScene()
    {
        Debug.Log("LoadNextSceneBtn");
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
        txtRetryCnt.text = "���Դ�����" + GameUIConfig.retryCnt.ToString();
    }
}
