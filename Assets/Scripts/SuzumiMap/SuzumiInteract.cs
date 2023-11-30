using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//����̿� ��ȣ�ۿ��� �����ϴ� �ڵ�
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
