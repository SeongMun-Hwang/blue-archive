using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollowCharacter : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��� (���Ϸ�)
    public Tilemap tilemap; // �̵� ��踦 �����ϴ� Ÿ�ϸ�
    private Vector2 viewportSize; // ī�޶� ����Ʈ�� ũ��
    public Camera mainCamera;
    private void Start()
    {
        tilemap = FindObjectOfType<Tilemap>();
        mainCamera = Camera.main;

        // ī�޶��� ����Ʈ ũ�⸦ ����մϴ�.
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
            followPosition.z = mainCamera.transform.position.z; // ���� ī�޶��� Z ��ġ�� ����

            BoundsInt boundsInt = tilemap.cellBounds;
            Vector3 minWorld = tilemap.CellToWorld(new Vector3Int(boundsInt.xMin, boundsInt.yMin, 0));
            Vector3 maxWorld = tilemap.CellToWorld(new Vector3Int(boundsInt.xMax, boundsInt.yMax, 0));

            // Ÿ�ϸ� ��迡 ���� ī�޶� ��ġ�� Ŭ�����մϴ�.
            followPosition.x = Mathf.Clamp(followPosition.x, minWorld.x + viewportSize.x, maxWorld.x - viewportSize.x);
            followPosition.y = Mathf.Clamp(followPosition.y, minWorld.y + viewportSize.y, maxWorld.y - viewportSize.y);

            mainCamera.transform.position = followPosition; // ���� ī�޶� ��ġ ������Ʈ
        }
    }
}
