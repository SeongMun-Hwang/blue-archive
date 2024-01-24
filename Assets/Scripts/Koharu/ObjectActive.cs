using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectActive : MonoBehaviour
{
    public float activationDistance = 2.5f; // 활성화 거리
    public List<GameObject> interactBoxs; // 2D 스퀘어 오브젝트 리스트
    private Transform playerTransform; // 플레이어 위치
    
    void Start()
    {
        interactBoxs = new List<GameObject>(GameObject.FindGameObjectsWithTag("InteractBox"));
        playerTransform = this.transform; // 플레이어 위치 찾기
    }
    void Update()
    {
        foreach (GameObject square in interactBoxs)
        {
            if (square != null)
            {
                float distanceX = Mathf.Abs(playerTransform.position.x - square.transform.position.x);
                bool isActive = distanceX <= activationDistance;
                square.SetActive(isActive);

                // 디버깅 로그
                Debug.Log($"Square: {square.name}, Distance: {distanceX}, IsActive: {isActive}");
            }
        }
    }
}
