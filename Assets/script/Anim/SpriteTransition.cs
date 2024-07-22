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

        // 设置初始位置和精灵
        transform.position = startPoint;
 
        spriteRenderer.color = new Color(1, 1, 1, 1); // 确保精灵完全不透明

        // 移动游戏对象
        LeanTween.move(gameObject, endPoint, duration).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
        {
            unityAction();
            StartCoroutine(CallBack());
        });


        //  请帮我转向 vec 方向
        Vector2 direction = endPoint - startPoint;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 假设需要根据x轴的方向决定是否镜像翻转
        if (direction.x < 0)
        {
            angle += 180f; // 旋转180度，实现镜像翻转
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
