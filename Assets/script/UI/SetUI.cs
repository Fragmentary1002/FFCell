using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetUI : MonoBehaviour
{
    public Button goToLevelSelectionButton; // �ص�ѡ�صİ�ť
    public Button exitButton; // �˳���Ϸ�İ�ť

    // Start is called before the first frame update
    void Start()
    {
        if (goToLevelSelectionButton != null)
        {
            goToLevelSelectionButton.onClick.AddListener(GoToLevelSelection);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }

    private void GoToLevelSelection()
    {
        Debug.Log("GoToLevelSelection");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    private void ExitGame()
    {
        // �˳���Ϸ
        Application.Quit();
    }
}
