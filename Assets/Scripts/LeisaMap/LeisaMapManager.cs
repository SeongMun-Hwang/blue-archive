using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LeisaMapManager : MonoBehaviour
{
    private GameObject character;
    void Start()
    {
        GameObject characterPrefab = Resources.Load<GameObject>("KoharuZzang");
        character = Instantiate(characterPrefab);
        LeisaInteract leisaInteract = FindObjectOfType<LeisaInteract>();
        leisaInteract.Koharu = character;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
