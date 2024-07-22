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
                    spriteRenderer.sprite = unSelectedSprite; // 替换为非选择状态的精灵
                    break;
                case SelectedType.splitSelected:
                    spriteRenderer.sprite = splitSelectedSprite; // 替换为分裂选择状态的精灵
                    break;
                case SelectedType.selected:
                    spriteRenderer.sprite = selectedSprite; // 替换为选择状态的精灵
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
