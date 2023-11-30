using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//스즈미와 상호작용을 관리하는 코드
public class SuzumiInteract : MonoBehaviour
{
    public GameObject ClosedSuzumi;
    public GameObject OpenedSuzumi;
    public GameObject Koharu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void Interact()
    {
        if (!OpenedSuzumi.activeSelf)
        {
            OpenedSuzumi.SetActive(true);
        }
        else if (OpenedSuzumi.activeSelf)
        {
            OpenedSuzumi.SetActive(false);
        }
    }
}
