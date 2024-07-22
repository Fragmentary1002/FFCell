using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToSceneButton : MonoBehaviour
{
    public Button returnButton; // 返回场景的按钮
    public int sceneIndex; // 要返回的场景索引

    // Start is called before the first frame update
    void Start()
    {
        if (returnButton != null)
        {
            returnButton.onClick.AddListener(ReturnToScene);
        }
    }

    private void ReturnToScene()
    {
        Debug.Log("Returning to scene: " + sceneIndex);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
