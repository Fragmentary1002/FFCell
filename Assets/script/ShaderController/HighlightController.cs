using UnityEngine;

public class HighlightController : MonoBehaviour
{
    // 对象的 Renderer 组件引用
    private Renderer objectRenderer;

    // 高亮 Shader 的材质
    public Material highlightMaterial;

    // 对象的原始材质
    private Material originalMaterial;

    // 标记高亮是否激活
    private bool isHighlighted = false;

    private void Start()
    {
        // 获取对象的 Renderer 组件
        objectRenderer = GetComponent<Renderer>();

        // 存储对象的原始材质
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }
    }

    private void Update()
    {
        // 演示用，在 Update 方法中检测 H 键按下事件来切换高亮效果
        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleHighlight();
        }
    }

    public void ToggleHighlight()
    {
        if (objectRenderer == null || highlightMaterial == null || originalMaterial == null)
        {
            Debug.LogWarning("HighlightController: 缺少必要的组件或材质。");
            return;
        }

        if (isHighlighted)
        {
            // 恢复原始材质
            objectRenderer.material = originalMaterial;
        }
        else
        {
            // 应用高亮材质
            objectRenderer.material = highlightMaterial;
        }

        // 切换高亮状态
        isHighlighted = !isHighlighted;
    }


    public void SetHighlight(bool status)
    {
        objectRenderer = GetComponent<Renderer>();
        if (status)
        {
            objectRenderer.material = highlightMaterial;
        }else
        {
            objectRenderer.material = originalMaterial;
        }
    }
}
