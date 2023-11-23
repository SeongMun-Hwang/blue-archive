using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SuzumiMapManager : MonoBehaviour
{
    public Tilemap tilemap; // 캐릭터가 이동할 타일맵 참조
    // Start is called before the first frame update
    void Start()
    {
        //리소스 폴더에서 코하루 동적 로딩
        GameObject characterPrefab = Resources.Load<GameObject>("KoharuZzang");
        GameObject character = Instantiate(characterPrefab);
        //메인 카메라에 코하루 연결
        CameraFollowCharacter cameraScript = FindObjectOfType<CameraFollowCharacter>();
        cameraScript.target = character.transform;
        //스즈미 상호작용에 코하루 연결
        SuzumiInteract suzumiInteract = FindObjectOfType<SuzumiInteract>();
        suzumiInteract.Koharu = character;
        //코하루 캐릭터에 타일맵 할당
        MoveKoharu moveKoharu = character.GetComponent<MoveKoharu>();
        moveKoharu.tilemap = tilemap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
