using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    public Transform target; // ���� ����� Transform
    public float smoothing = 5f; // ī�޶� �������� �ε巯�� ����
    public Vector2 offset; // ī�޶�� ��� ���� ������

    private void FixedUpdate()
    {
        // ����� X ��ǥ�� ī�޶��� ���� Y, Z ��ǥ�� ����Ͽ� ��ǥ ��ġ�� ����մϴ�.
        Vector3 targetCamPos = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z + offset.y);

        // Lerp �Լ��� ����Ͽ� ���� ��ġ���� ��ǥ ��ġ���� �ε巴�� �̵��մϴ�.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
