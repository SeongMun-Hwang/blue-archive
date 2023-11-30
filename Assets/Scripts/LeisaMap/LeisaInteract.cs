using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeisaInteract : MonoBehaviour
{
    public GameObject Koharu;
    public GameObject IdleLeisa;
    public GameObject ClosedLeisa;
    public GameObject SurpriseLeisa;
    public GameObject MessageBox;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }
    private void Interact()
    {
        bool isSurpriseActive = SurpriseLeisa.activeSelf;

        SurpriseLeisa.SetActive(!isSurpriseActive);
        IdleLeisa.SetActive(isSurpriseActive);
    }
}
