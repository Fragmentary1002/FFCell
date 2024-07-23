using UnityEngine;

public class ChildNode : MonoBehaviour
{
    public Sprite unSelectedSprite;
    public Sprite splitSelectedSprite;
    public Sprite selectedSprite;

    public void UpdateSprite(SelectedType selectedType)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            switch (selectedType)
            {
                case SelectedType.unSelected:
                    spriteRenderer.sprite = unSelectedSprite; // �滻Ϊ��ѡ��״̬�ľ���
                    break;
                case SelectedType.splitSelected:
                    spriteRenderer.sprite = splitSelectedSprite; // �滻Ϊ����ѡ��״̬�ľ���
                    break;
                case SelectedType.selected:
                    spriteRenderer.sprite = selectedSprite; // �滻Ϊѡ��״̬�ľ���
                    break;
                default:
                    Debug.LogWarning("Unknown SelectedType");
                    break;
            }
        }
        else
        {
            Debug.LogWarning("SpriteRenderer not found on ChildNode");
        }
    }
}
