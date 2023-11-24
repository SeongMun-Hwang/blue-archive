using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollowCharacter : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상 (코하루)
    public Tilemap tilemap; // 이동 경계를 제공하는 타일맵
    private Vector2 viewportSize; // 카메라 뷰포트의 크기
    public Camera mainCamera;
    private void Start()
    {
        tilemap = FindObjectOfType<Tilemap>();
        mainCamera = Camera.main;

        // 카메라의 뷰포트 크기를 계산합니다.
        float cameraHalfHeight = mainCamera.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;
        viewportSize = new Vector2(cameraHalfWidth, cameraHalfHeight);

        target = this.transform;
    }

    private void LateUpdate()
    {
        if (target != null && tilemap != null && mainCamera != null)
        {
            Vector3 followPosition = target.position;
            followPosition.z = mainCamera.transform.position.z; // 메인 카메라의 Z 위치를 유지

            BoundsInt boundsInt = tilemap.cellBounds;
            Vector3 minWorld = tilemap.CellToWorld(new Vector3Int(boundsInt.xMin, boundsInt.yMin, 0));
            Vector3 maxWorld = tilemap.CellToWorld(new Vector3Int(boundsInt.xMax, boundsInt.yMax, 0));

            // 타일맵 경계에 따라 카메라 위치를 클램핑합니다.
            followPosition.x = Mathf.Clamp(followPosition.x, minWorld.x + viewportSize.x, maxWorld.x - viewportSize.x);
            followPosition.y = Mathf.Clamp(followPosition.y, minWorld.y + viewportSize.y, maxWorld.y - viewportSize.y);

            mainCamera.transform.position = followPosition; // 메인 카메라 위치 업데이트
        }
    }
}
