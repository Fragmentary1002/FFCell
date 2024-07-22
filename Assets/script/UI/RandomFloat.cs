using UnityEngine;

public class RandomFloat : MonoBehaviour
{
    // 定义浮动范围
    public float floatRange = 20f;
    // 定义动画时长
    public float duration = 1.0f;

    private RectTransform rectTransform;
    private Vector2 startPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
        MoveToRandomPosition();
    }

    void MoveToRandomPosition()
    {
        // 生成新的随机目标位置
        Vector2 targetPosition = startPosition + new Vector2(
            Random.Range(-floatRange, floatRange),
            Random.Range(-floatRange, floatRange)
        );
        float randDuration = duration + Random.Range(-0.5f, 0.5f);
        // 使用 LeanTween 移动到目标位置
        LeanTween.move(rectTransform, targetPosition, randDuration).setOnComplete(MoveToRandomPosition);
    }
}