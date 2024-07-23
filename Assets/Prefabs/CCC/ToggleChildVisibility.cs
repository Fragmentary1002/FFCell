using UnityEngine;
using UnityEngine.UI;

public class ToggleChildVisibility : MonoBehaviour
{
    public GameObject childObject; // Ҫ���Ƶ�������
    public Button toggleButton;    // ���ڿ�����ʾ���صİ�ť

    void Start()
    {
        // ȷ����ť���������Ѿ���Inspector�������ȷ����
        if (toggleButton != null && childObject != null)
        {
            // ��Ӱ�ť����¼�����
            toggleButton.onClick.AddListener(ToggleVisibility);
            this.childObject.SetActive(false);
        }
    }

    void ToggleVisibility()
    {
        if (childObject != null)
        {
            // �л����������ʾ״̬
            childObject.SetActive(!childObject.activeSelf);
        }
    }
}
