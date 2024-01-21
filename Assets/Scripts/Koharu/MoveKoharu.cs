using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MoveKoharu : MonoBehaviour
{
    public float moveSpeed = 5.0f; //코하루 이동 시간
    private Rigidbody2D rb;
    private Vector2 lastDirection = Vector2.right;
    private bool isFlipping = false;
    private float flipTime = 0.25f; //코하루 a,s 입력 변환 시 회전하는 시간
    // MainBackGround 컴포넌트, 코하루 이동 공간
    public Tilemap tilemap;
    private Vector2 boundaryMin; // 배경의 최소 경계값
    private Vector2 boundaryMax; // 배경의 최대 경계값
    //애니메이션
    private Animator animator;
    private bool isLoadSaveOpen = false; //로드세이브 창 열기 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        tilemap = FindObjectOfType<Tilemap>();

        if (tilemap != null)
        {
            // 타일맵의 셀 경계를 가져옵니다.
            BoundsInt bounds = tilemap.cellBounds;

            // 타일맵의 전체 경계를 계산합니다.
            Vector3 minCell = tilemap.CellToWorld(new Vector3Int(bounds.xMin, bounds.yMin, 0));
            Vector3 maxCell = tilemap.CellToWorld(new Vector3Int(bounds.xMax, bounds.yMax, 0));

            // 캐릭터의 크기를 고려하여 경계값을 조정합니다.
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

        // 이동이 있을 때만 업데이트한다.
        if (moveInput != Vector2.zero)
        {
            // 예정된 새 위치를 계산합니다.
            Vector2 newPosition = rb.position + moveVelocity * Time.fixedDeltaTime;

            // 새 위치가 경계 안에 있는지 확인하고, 필요하다면 조정합니다.
            newPosition.x = Mathf.Clamp(newPosition.x, boundaryMin.x, boundaryMax.x);
            newPosition.y = Mathf.Clamp(newPosition.y, boundaryMin.y, boundaryMax.y);

            rb.MovePosition(newPosition);


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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("StartMenu");
            Debug.Log("working");

            //환경설정 리소스 로드
            //GameObject settingWindow = Resources.Load<GameObject>("SettingCanvas");
            //Instantiate(settingWindow);
            if (!isLoadSaveOpen)
            {
                // LoadSave 씬을 불러오고 상태를 업데이트
                SceneManager.LoadScene("LoadSave", LoadSceneMode.Additive);
                isLoadSaveOpen = true;
            }
            else
            {
                // LoadSave 씬을 닫고 상태를 업데이트
                SceneManager.UnloadSceneAsync("LoadSave");
                isLoadSaveOpen = false;
            }
        }
    }

    void StartFlip(float targetScaleX)
    {
        if (isFlipping) return; // 이미 반전 중이라면 실행하지 않음
        StartCoroutine(Flip(targetScaleX));
    }
    //좌->우, 우->좌 이동 시 코하루 회전
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
