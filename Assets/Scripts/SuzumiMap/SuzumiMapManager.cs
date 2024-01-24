using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class SuzumiMapManager : MonoBehaviour
{
    private GameObject character;
    void Start()
    {
        //리소스 폴더에서 코하루 동적 로딩
        GameObject characterPrefab = Resources.Load<GameObject>("KoharuZzang");
        character = Instantiate(characterPrefab);
        //스즈미 상호작용에 코하루 연결
        SuzumiInteract suzumiInteract = FindObjectOfType<SuzumiInteract>();
        suzumiInteract.Koharu = character;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
