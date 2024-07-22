using UnityEngine;

public class RandomFloat : MonoBehaviour
{
    // ���帡����Χ
    public float floatRange = 20f;
    // ���嶯��ʱ��
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
        // �����µ����Ŀ��λ��
        Vector2 targetPosition = startPosition + new Vector2(
            Random.Range(-floatRange, floatRange),
            Random.Range(-floatRange, floatRange)
        );
        float randDuration = duration + Random.Range(-0.5f, 0.5f);
        // ʹ�� LeanTween �ƶ���Ŀ��λ��
        LeanTween.move(rectTransform, targetPosition, randDuration).setOnComplete(MoveToRandomPosition);
    }
}