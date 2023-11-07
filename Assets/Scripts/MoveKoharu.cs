using UnityEngine;
using System.Collections;

public class MoveKoharu : MonoBehaviour
{
    public float moveSpeed = 5.0f; //���Ϸ� �̵� �ð�
    private Rigidbody2D rb;
    private Vector2 lastDirection = Vector2.right;
    private bool isFlipping = false;
    private float flipTime = 0.25f; //���Ϸ� a,s �Է� ��ȯ �� ȸ���ϴ� �ð�

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveVelocity = moveInput.normalized * moveSpeed;

        // �̵��� ���� ���� ������Ʈ�Ѵ�.
        if (moveInput != Vector2.zero)
        {
            // ������Ʈ�� �̵���Ų��.
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

            // �����̳� ���������� �̵��� �� �̹��� ������ ������Ʈ�Ѵ�.
            if (moveInput.x > 0 && !Mathf.Approximately(transform.localScale.x, 1f))
            {
                StartFlip(1f);
            }
            else if (moveInput.x < 0 && !Mathf.Approximately(transform.localScale.x, -1f))
            {
                StartFlip(-1f);
            }

            // ������ ������ ������Ʈ�Ѵ�.
            lastDirection = moveInput.x < 0 ? Vector2.left : Vector2.right;
        }
    }

    void StartFlip(float targetScaleX)
    {
        if (isFlipping) return; // �̹� ���� ���̶�� �������� ����
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

        transform.localScale = targetScale; // ���� �����Ϸ� Ȯ���ϰ� ����
        isFlipping = false;
    }
}
