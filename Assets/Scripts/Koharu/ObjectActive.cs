using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActive : MonoBehaviour
{
    public float activationDistance = 2.5f; // Ȱ��ȭ �Ÿ�
    public List<GameObject> interactBoxs; // 2D ������ ������Ʈ ����Ʈ
    private Transform playerTransform; // �÷��̾� ��ġ
    void Start()
    {
        interactBoxs = new List<GameObject>(GameObject.FindGameObjectsWithTag("InteractBox"));
        playerTransform = this.transform; // �÷��̾� ��ġ ã��
    }
    void Update()
    {
        foreach (GameObject square in interactBoxs)
        {
            float distanceX = Mathf.Abs(playerTransform.position.x - square.transform.position.x);
            square.SetActive(distanceX <= activationDistance);
        }
    }
}
