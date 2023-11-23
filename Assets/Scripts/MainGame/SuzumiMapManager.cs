using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SuzumiMapManager : MonoBehaviour
{
    public Tilemap tilemap; // ĳ���Ͱ� �̵��� Ÿ�ϸ� ����
    // Start is called before the first frame update
    void Start()
    {
        //���ҽ� �������� ���Ϸ� ���� �ε�
        GameObject characterPrefab = Resources.Load<GameObject>("KoharuZzang");
        GameObject character = Instantiate(characterPrefab);
        //���� ī�޶� ���Ϸ� ����
        CameraFollowCharacter cameraScript = FindObjectOfType<CameraFollowCharacter>();
        cameraScript.target = character.transform;
        //����� ��ȣ�ۿ뿡 ���Ϸ� ����
        SuzumiInteract suzumiInteract = FindObjectOfType<SuzumiInteract>();
        suzumiInteract.Koharu = character;
        //���Ϸ� ĳ���Ϳ� Ÿ�ϸ� �Ҵ�
        MoveKoharu moveKoharu = character.GetComponent<MoveKoharu>();
        moveKoharu.tilemap = tilemap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
