using UnityEngine;

public class HighlightController : MonoBehaviour
{
    // ����� Renderer �������
    private Renderer objectRenderer;

    // ���� Shader �Ĳ���
    public Material highlightMaterial;

    // �����ԭʼ����
    private Material originalMaterial;

    // ��Ǹ����Ƿ񼤻�
    private bool isHighlighted = false;

    private void Start()
    {
        // ��ȡ����� Renderer ���
        objectRenderer = GetComponent<Renderer>();

        // �洢�����ԭʼ����
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }
    }

    private void Update()
    {
        // ��ʾ�ã��� Update �����м�� H �������¼����л�����Ч��
        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleHighlight();
        }
    }

    public void ToggleHighlight()
    {
        if (objectRenderer == null || highlightMaterial == null || originalMaterial == null)
        {
            Debug.LogWarning("HighlightController: ȱ�ٱ�Ҫ���������ʡ�");
            return;
        }

        if (isHighlighted)
        {
            // �ָ�ԭʼ����
            objectRenderer.material = originalMaterial;
        }
        else
        {
            // Ӧ�ø�������
            objectRenderer.material = highlightMaterial;
        }

        // �л�����״̬
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
