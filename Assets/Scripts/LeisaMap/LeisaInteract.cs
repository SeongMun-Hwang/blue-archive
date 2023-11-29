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
    public GameObject MoveMapBox;

    private float interactDistance = 4;

    void Update()
    {
        //����̶� ���Ϸ� �Ÿ�
        float distanceToLeisa = Mathf.Abs(Koharu.transform.position.x - IdleLeisa.transform.position.x);
        //���Ϸ�� �� �̵� �ڽ� �Ÿ�
        float distanceToMoveMap = Mathf.Abs(Koharu.transform.position.x - MoveMapBox.transform.position.x);
        // ����̿� F�� ��ȣ�ۿ�
        if (distanceToLeisa <= interactDistance)
        {
            MessageBox.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
        }
        else if (distanceToLeisa >= interactDistance)
        {
            MessageBox.SetActive(false);
        }
        //�� �̵� ��ȣ �ۿ�
        if (distanceToMoveMap <= interactDistance)
        {
            MoveMapBox.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("SuzumiMap");
            }
        }
        else if (distanceToMoveMap >= interactDistance)
        {
            MoveMapBox.SetActive(false);
        }
    }
    private void Interact()
    {
        bool isSurpriseActive = SurpriseLeisa.activeSelf;

        SurpriseLeisa.SetActive(!isSurpriseActive);
        IdleLeisa.SetActive(isSurpriseActive);
    }
}
