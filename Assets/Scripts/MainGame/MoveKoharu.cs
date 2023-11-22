using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

public class MoveKoharu : MonoBehaviour
{
    public float moveSpeed = 5.0f; //���Ϸ� �̵� �ð�
    private Rigidbody2D rb;
    private Vector2 lastDirection = Vector2.right;
    private bool isFlipping = false;
    private float flipTime = 0.25f; //���Ϸ� a,s �Է� ��ȯ �� ȸ���ϴ� �ð�
    // MainBackGround ������Ʈ, ���Ϸ� �̵� ����
    public Tilemap tilemap;
    private Vector2 boundaryMin; // ����� �ּ� ��谪
    private Vector2 boundaryMax; // ����� �ִ� ��谪
    //�ִϸ��̼�
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (tilemap != null)
        {
            // Ÿ�ϸ��� ���� ��踦 �����ɴϴ�.
            BoundsInt bounds = tilemap.cellBounds;

            // ���� ��ǥ�� ����� �ּ� �� �ִ� ����Ʈ�� ����մϴ�.
            Vector3 minLocal = tilemap.CellToLocalInterpolated(new Vector3Int(bounds.xMin, bounds.yMin, 0));
            Vector3 maxLocal = tilemap.CellToLocalInterpolated(new Vector3Int(bounds.xMax, bounds.yMax, 0));

            // ���� ��ǥ�� ��ȯ�մϴ�.
            Vector3 minWorld = tilemap.LocalToWorld(minLocal);
            Vector3 maxWorld = tilemap.LocalToWorld(maxLocal);

            // ��谪�� �����մϴ�.
            boundaryMin = new Vector2(minWorld.x, minWorld.y+2);
            boundaryMax = new Vector2(maxWorld.x, maxWorld.y-6);

            // ��踦 ������ ������ �� �ֽ��ϴ� (��: ĳ������ ũ�� ���� ����Ͽ�).
        }
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveVelocity = moveInput.normalized * moveSpeed;

        // �̵��� ���� ���� ������Ʈ�Ѵ�.
        if (moveInput != Vector2.zero)
        {
            // ������ �� ��ġ�� ����մϴ�.
            Vector2 newPosition = rb.position + moveVelocity * Time.fixedDeltaTime;

            // �� ��ġ�� ��� �ȿ� �ִ��� Ȯ���ϰ�, �ʿ��ϴٸ� �����մϴ�.
            newPosition.x = Mathf.Clamp(newPosition.x, boundaryMin.x, boundaryMax.x);
            newPosition.y = Mathf.Clamp(newPosition.y, boundaryMin.y, boundaryMax.y);

            rb.MovePosition(newPosition);


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
    //��->��, ��->�� �̵� �� ���Ϸ� ȸ��
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
