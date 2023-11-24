using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class SuzumiMapManager : MonoBehaviour
{
    public Tilemap tilemap;
    private GameObject character;
    void Start()
    {
        tilemap = FindObjectOfType<Tilemap>();
        //���ҽ� �������� ���Ϸ� ���� �ε�
        GameObject characterPrefab = Resources.Load<GameObject>("KoharuZzang");
        character = Instantiate(characterPrefab);
        //����� ��ȣ�ۿ뿡 ���Ϸ� ����
        SuzumiInteract suzumiInteract = FindObjectOfType<SuzumiInteract>();
        suzumiInteract.Koharu = character;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
