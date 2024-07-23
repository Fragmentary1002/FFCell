using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumePanel : MonoBehaviour
{

    public Button toggleVolumePanelButton;
    public Button exitButton;


    private void Start()
    {

        // 添加音乐
        foreach (var volume in GameUIConfig.bgmVolumesPath)
        {
            MusicMgr.GetInstance().PlayBkMusic(volume);
        }

        // 为按钮添加监听事件
        toggleVolumePanelButton.onClick.AddListener(ToggleVolumePanel);
        exitButton.onClick.AddListener(ExitGame);

        // 初始状态下隐藏音量控制面板
     
    }

    private void OnMusicValueChange(float value)
    {
        MusicMgr.GetInstance().ChangeBKValue(value);
    }

    private void OnSoundValueChange(float value)
    {
        MusicMgr.GetInstance().ChangeSoundValue(value);
    }

    private void ToggleVolumePanel()
    {
        Debug.Log("ToggleVolumePanel");
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    private void ExitGame()
    {
        // 退出游戏
        Application.Quit();
    }
}
