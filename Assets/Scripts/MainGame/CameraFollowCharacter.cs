using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollowCharacter : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상 (코하루)
    public Tilemap tilemap; // 이동 경계를 제공하는 타일맵
    private Vector2 viewportSize; // 카메라 뷰포트의 크기

    private void Start()
    {
        // 카메라의 뷰포트 크기를 계산합니다.
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;
        viewportSize = new Vector2(cameraHalfWidth, cameraHalfHeight);
    }

    private void LateUpdate()
    {
        if (target != null && tilemap != null)
        {
            // 카메라의 뷰포트가 Tilemap 경계 안에 있도록 조정합니다.
            Vector3 followPosition = target.position;
            followPosition.z = transform.position.z; // 카메라의 Z 위치는 변하지 않게 유지합니다.

            // Tilemap 월드 좌표 경계를 계산합니다.
            BoundsInt boundsInt = tilemap.cellBounds;
            Vector3 minWorld = tilemap.CellToWorld(new Vector3Int(boundsInt.xMin, boundsInt.yMin, 0));
            Vector3 maxWorld = tilemap.CellToWorld(new Vector3Int(boundsInt.xMax, boundsInt.yMax, 0));

            // 카메라 위치를 클램핑합니다.
            Vector3 clampedPosition = new Vector3(
                Mathf.Clamp(followPosition.x, minWorld.x + viewportSize.x, maxWorld.x - viewportSize.x),
                Mathf.Clamp(followPosition.y, minWorld.y + viewportSize.y, maxWorld.y - viewportSize.y),
                followPosition.z);

            // 카메라 위치를 업데이트합니다.
            transform.position = clampedPosition;
        }
    }
}
