using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeisaMapManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject characterPrefab = Resources.Load<GameObject>("KoharuZzang");
        GameObject character = Instantiate(characterPrefab);
        //SuzumiInteract suzumiInteract = FindObjectOfType<SuzumiInteract>();
        //suzumiInteract.Koharu = character;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
