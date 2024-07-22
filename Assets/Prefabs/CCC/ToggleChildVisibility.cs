using UnityEngine;
using UnityEngine.UI;

public class ToggleChildVisibility : MonoBehaviour
{
    public GameObject childObject; // 要控制的子物体
    public Button toggleButton;    // 用于控制显示隐藏的按钮

    void Start()
    {
        // 确保按钮和子物体已经在Inspector面板中正确设置
        if (toggleButton != null && childObject != null)
        {
            // 添加按钮点击事件监听
            toggleButton.onClick.AddListener(ToggleVisibility);
            this.childObject.SetActive(false);
        }
    }

    void ToggleVisibility()
    {
        if (childObject != null)
        {
            // 切换子物体的显示状态
            childObject.SetActive(!childObject.activeSelf);
        }
    }
}
