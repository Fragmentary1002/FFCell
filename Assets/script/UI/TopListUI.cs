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
        // ���ð�ť����¼�
        setBtn.onClick.AddListener(() =>
        {
            setWnd?.SetActive(!setWnd.activeSelf);
        });

        // ���¿�ʼ��ť����¼�
        startAgainBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        // ·�갴ť����¼�
        fingerpostBtn.onClick.AddListener(() =>
        {
            // ���������·�갴ť���߼�
            Debug.Log("Fingerpost button clicked.");
        });
    }

    // Update is called once per frame
    void Update()
    {
        // ������������������߼�
    }
}
