using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetUI : MonoBehaviour
{
    public Button goToLevelSelectionButton; // 回到选关的按钮
    public Button exitButton; // 退出游戏的按钮

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
        // 退出游戏
        Application.Quit();
    }
}
