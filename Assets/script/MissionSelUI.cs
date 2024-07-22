using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionSelUI : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Button> missionButs;

    void Start()
    {
        for (int i = 0; i < missionButs.Count; i++)
        {
            int index = i; // Create a local copy of i
            missionButs[index].onClick.AddListener(() =>
            {
                SceneManager.LoadScene(index + 2, LoadSceneMode.Single);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
