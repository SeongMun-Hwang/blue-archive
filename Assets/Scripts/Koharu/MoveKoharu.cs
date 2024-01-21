using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

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
    private bool isLoadSaveOpen = false; //�ε弼�̺� â ���� 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        tilemap = FindObjectOfType<Tilemap>();

        if (tilemap != null)
        {
            // Ÿ�ϸ��� �� ��踦 �����ɴϴ�.
            BoundsInt bounds = tilemap.cellBounds;

            // Ÿ�ϸ��� ��ü ��踦 ����մϴ�.
            Vector3 minCell = tilemap.CellToWorld(new Vector3Int(bounds.xMin, bounds.yMin, 0));
            Vector3 maxCell = tilemap.CellToWorld(new Vector3Int(bounds.xMax, bounds.yMax, 0));

            // ĳ������ ũ�⸦ ����Ͽ� ��谪�� �����մϴ�.
            float characterWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
            float characterHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
            boundaryMin = new Vector2(minCell.x + characterWidth, minCell.y + characterHeight);
            boundaryMax = new Vector2(maxCell.x - characterWidth, maxCell.y - characterHeight);
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("StartMenu");
            Debug.Log("working");

            //ȯ�漳�� ���ҽ� �ε�
            //GameObject settingWindow = Resources.Load<GameObject>("SettingCanvas");
            //Instantiate(settingWindow);
            if (!isLoadSaveOpen)
            {
                // LoadSave ���� �ҷ����� ���¸� ������Ʈ
                SceneManager.LoadScene("LoadSave", LoadSceneMode.Additive);
                isLoadSaveOpen = true;
            }
            else
            {
                // LoadSave ���� �ݰ� ���¸� ������Ʈ
                SceneManager.UnloadSceneAsync("LoadSave");
                isLoadSaveOpen = false;
            }
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
