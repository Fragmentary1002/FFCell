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

        // �������
        foreach (var volume in GameUIConfig.bgmVolumesPath)
        {
            MusicMgr.GetInstance().PlayBkMusic(volume);
        }

        // Ϊ��ť��Ӽ����¼�
        toggleVolumePanelButton.onClick.AddListener(ToggleVolumePanel);
        exitButton.onClick.AddListener(ExitGame);

        // ��ʼ״̬�����������������
     
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
        // �˳���Ϸ
        Application.Quit();
    }
}
