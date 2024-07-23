using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectUI : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;

    public int off = 1;
    public int sceneIndex1 = 1;
    public int sceneIndex2 = 2;
    public int sceneIndex3 = 3;
    public int sceneIndex4 = 4;
    public int sceneIndex5 = 5;
    public int sceneIndex6 = 6;

    void Start()
    {
        button1.onClick.AddListener(() => LoadScene(sceneIndex1+ off));
        button2.onClick.AddListener(() => LoadScene(sceneIndex2+ off));
        button3.onClick.AddListener(() => LoadScene(sceneIndex3 + off));
        button4.onClick.AddListener(() => LoadScene(sceneIndex4 + off));
        button5.onClick.AddListener(() => LoadScene(sceneIndex5 + off));
        button6.onClick.AddListener(() => LoadScene(sceneIndex6 + off));
    }

    private void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
