using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToSceneButton : MonoBehaviour
{
    public Button returnButton; // ���س����İ�ť
    public int sceneIndex; // Ҫ���صĳ�������

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
