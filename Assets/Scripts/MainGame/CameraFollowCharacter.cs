using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollowCharacter : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��� (���Ϸ�)
    public Tilemap tilemap; // �̵� ��踦 �����ϴ� Ÿ�ϸ�
    private Vector2 viewportSize; // ī�޶� ����Ʈ�� ũ��

    private void Start()
    {
        // ī�޶��� ����Ʈ ũ�⸦ ����մϴ�.
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;
        viewportSize = new Vector2(cameraHalfWidth, cameraHalfHeight);
    }

    private void LateUpdate()
    {
        if (target != null && tilemap != null)
        {
            // ī�޶��� ����Ʈ�� Tilemap ��� �ȿ� �ֵ��� �����մϴ�.
            Vector3 followPosition = target.position;
            followPosition.z = transform.position.z; // ī�޶��� Z ��ġ�� ������ �ʰ� �����մϴ�.

            // Tilemap ���� ��ǥ ��踦 ����մϴ�.
            BoundsInt boundsInt = tilemap.cellBounds;
            Vector3 minWorld = tilemap.CellToWorld(new Vector3Int(boundsInt.xMin, boundsInt.yMin, 0));
            Vector3 maxWorld = tilemap.CellToWorld(new Vector3Int(boundsInt.xMax, boundsInt.yMax, 0));

            // ī�޶� ��ġ�� Ŭ�����մϴ�.
            Vector3 clampedPosition = new Vector3(
                Mathf.Clamp(followPosition.x, minWorld.x + viewportSize.x, maxWorld.x - viewportSize.x),
                Mathf.Clamp(followPosition.y, minWorld.y + viewportSize.y, maxWorld.y - viewportSize.y),
                followPosition.z);

            // ī�޶� ��ġ�� ������Ʈ�մϴ�.
            transform.position = clampedPosition;
        }
    }
}
