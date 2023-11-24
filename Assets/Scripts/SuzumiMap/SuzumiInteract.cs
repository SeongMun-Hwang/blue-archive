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
    public GameObject InteractBox;
    public GameObject MoveMapBox;
    public float interactDistance; //���Ϸ�� ����� �Ÿ�

    public void Update()
    {
        //����̶� ���Ϸ� �Ÿ�
        float distanceToSuzumi = Mathf.Abs(Koharu.transform.position.x - ClosedSuzumi.transform.position.x);
        //���Ϸ�� �� �̵� �ڽ� �Ÿ�
        float distanceToMoveMap = Mathf.Abs(Koharu.transform.position.x - MoveMapBox.transform.position.x);
        // ����̿� F�� ��ȣ�ۿ�
        if (distanceToSuzumi <= interactDistance) {
            InteractBox.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)){
                Interact();
            }
        }
        else if (distanceToSuzumi >= interactDistance)
        {
            InteractBox.SetActive(false);
        }
        //�� �̵� ��ȣ �ۿ�
        if (distanceToMoveMap <= interactDistance)
        {
            MoveMapBox.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("LeisaMap");
            }
        }
        else if (distanceToMoveMap >= interactDistance)
        {
            MoveMapBox.SetActive(false);
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
