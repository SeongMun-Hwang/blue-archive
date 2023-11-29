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
        //스즈미랑 코하루 거리
        float distanceToLeisa = Mathf.Abs(Koharu.transform.position.x - IdleLeisa.transform.position.x);
        //코하루랑 맵 이동 박스 거리
        float distanceToMoveMap = Mathf.Abs(Koharu.transform.position.x - MoveMapBox.transform.position.x);
        // 스즈미와 F로 상호작용
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
        //맵 이동 상호 작용
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
