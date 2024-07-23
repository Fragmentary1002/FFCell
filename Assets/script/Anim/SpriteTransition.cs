using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SpriteTransition : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float duration = 2f;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        PoolMgr.GetInstance().Clear();
    }

    public void StartAnim(Vector3 startPoint, Vector3 endPoint ,UnityAction unityAction)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        Debug.Log($"StartAnim___{startPoint}___{endPoint}");

        // ���ó�ʼλ�ú;���
        transform.position = startPoint;
 
        spriteRenderer.color = new Color(1, 1, 1, 1); // ȷ��������ȫ��͸��

        // �ƶ���Ϸ����
        LeanTween.move(gameObject, endPoint, duration).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
        {
            unityAction();
            StartCoroutine(CallBack());
        });


        //  �����ת�� vec ����
        Vector2 direction = endPoint - startPoint;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ������Ҫ����x��ķ�������Ƿ���ת
        if (direction.x < 0)
        {
            angle += 180f; // ��ת180�ȣ�ʵ�־���ת
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);


        float halfDuration = duration / 2;
        LeanTween.scaleY(gameObject, 0.7f, halfDuration).setOnComplete(() =>
        {
            LeanTween.scaleY(gameObject, 1, halfDuration);
        });

    }


    IEnumerator CallBack()
    {
        //yield return new WaitForSeconds(0.1f);
        PoolMgr.GetInstance().PushObj("Prefabs/MovePre", this.gameObject);
        transform.localScale = Vector3.one;
        yield return null;
    }
}
