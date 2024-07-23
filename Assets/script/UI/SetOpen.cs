using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 引入UI命名空间

public class SetOpen : MonoBehaviour
{
    public Button yourButton;   // 按钮
    public GameObject yourGameObject;  // 需要打开/关闭的GameObject

    // Start is called before the first frame update
    void Start()
    {
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(ToggleGameObject);  // 注册按钮事件
        }
        yourGameObject?.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ToggleGameObject()
    {
        if (yourGameObject != null)
        {
            // 切换GameObject的激活状态
            yourGameObject.SetActive(true);
        }
    }
}
