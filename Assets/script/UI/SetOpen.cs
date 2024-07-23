using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // ����UI�����ռ�

public class SetOpen : MonoBehaviour
{
    public Button yourButton;   // ��ť
    public GameObject yourGameObject;  // ��Ҫ��/�رյ�GameObject

    // Start is called before the first frame update
    void Start()
    {
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(ToggleGameObject);  // ע�ᰴť�¼�
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
            // �л�GameObject�ļ���״̬
            yourGameObject.SetActive(true);
        }
    }
}
