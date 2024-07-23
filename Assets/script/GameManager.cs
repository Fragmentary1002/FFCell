using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonAutoMono<GameManager>
{

   public void Start()
   {
        
        //DontDestroyOnLoad(this.gameObject);
    
    }

    public void OnEnable()
    {
        MusicMgr.GetInstance().PlayBkMusic("start");
    }

}
