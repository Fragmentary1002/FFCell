using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopListUI : MonoBehaviour
{
    public Button setBtn;
    public Button startAgainBtn;
    public Button fingerpostBtn;
    public GameObject setWnd;

    void Start()
    {
        // 设置按钮点击事件
        setBtn.onClick.AddListener(() =>
        {
            setWnd?.SetActive(!setWnd.activeSelf);
        });

        // 重新开始按钮点击事件
        startAgainBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        // 路标按钮点击事件
        fingerpostBtn.onClick.AddListener(() =>
        {
            // 在这里添加路标按钮的逻辑
            Debug.Log("Fingerpost button clicked.");
        });
    }

    // Update is called once per frame
    void Update()
    {
        // 可以在这里添加其他逻辑
    }
}
