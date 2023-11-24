using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����̿� ��ȣ�ۿ��� �����ϴ� �ڵ�
public class SuzumiInteract : MonoBehaviour
{
    public GameObject ClosedSuzumi;
    public GameObject OpenedSuzumi;
    public GameObject Koharu;
    public GameObject InteractBox;
    public float interactDistance; //���Ϸ�� ����� �Ÿ�

    public void Update()
    {
        float distanceToSuzumi = Mathf.Abs(Koharu.transform.position.x - ClosedSuzumi.transform.position.x);
        // F�� ��ȣ�ۿ�
        Debug.Log(distanceToSuzumi);
        if (distanceToSuzumi <= interactDistance) {
            InteractBox.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)){
                Interact();
            }
        } 
        else if(distanceToSuzumi >= interactDistance)
        {
            InteractBox.SetActive(false);
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
