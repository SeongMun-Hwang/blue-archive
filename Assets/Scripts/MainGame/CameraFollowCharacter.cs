using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    public Transform target; // 따라갈 대상의 Transform
    public float smoothing = 5f; // 카메라 움직임의 부드러움 정도
    public Vector2 offset; // 카메라와 대상 간의 오프셋

    private void FixedUpdate()
    {
        // 대상의 X 좌표와 카메라의 현재 Y, Z 좌표를 사용하여 목표 위치를 계산합니다.
        Vector3 targetCamPos = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z + offset.y);

        // Lerp 함수를 사용하여 현재 위치에서 목표 위치까지 부드럽게 이동합니다.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
