using UnityEngine;
using System.Collections;

public class MoveKoharu : MonoBehaviour
{
    public float moveSpeed = 5.0f; //코하루 이동 시간
    private Rigidbody2D rb;
    private Vector2 lastDirection = Vector2.right;
    private bool isFlipping = false;
    private float flipTime = 0.25f; //코하루 a,s 입력 변환 시 회전하는 시간

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveVelocity = moveInput.normalized * moveSpeed;

        // 이동이 있을 때만 업데이트한다.
        if (moveInput != Vector2.zero)
        {
            // 오브젝트를 이동시킨다.
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

            // 왼쪽이나 오른쪽으로 이동할 때 이미지 방향을 업데이트한다.
            if (moveInput.x > 0 && !Mathf.Approximately(transform.localScale.x, 1f))
            {
                StartFlip(1f);
            }
            else if (moveInput.x < 0 && !Mathf.Approximately(transform.localScale.x, -1f))
            {
                StartFlip(-1f);
            }

            // 마지막 방향을 업데이트한다.
            lastDirection = moveInput.x < 0 ? Vector2.left : Vector2.right;
        }
    }

    void StartFlip(float targetScaleX)
    {
        if (isFlipping) return; // 이미 반전 중이라면 실행하지 않음
        StartCoroutine(Flip(targetScaleX));
    }

    IEnumerator Flip(float targetScaleX)
    {
        isFlipping = true;

        float currentTime = 0f;
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(targetScaleX, originalScale.y, originalScale.z);

        while (currentTime < flipTime)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / flipTime;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale; // 최종 스케일로 확실하게 설정
        isFlipping = false;
    }
}
