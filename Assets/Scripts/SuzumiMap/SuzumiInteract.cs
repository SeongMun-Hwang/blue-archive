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
    public GameObject InteractBox;
    public GameObject MoveMapBox;
    public float interactDistance; //코하루와 스즈미 거리

    public void Update()
    {
        //스즈미랑 코하루 거리
        float distanceToSuzumi = Mathf.Abs(Koharu.transform.position.x - ClosedSuzumi.transform.position.x);
        //코하루랑 맵 이동 박스 거리
        float distanceToMoveMap = Mathf.Abs(Koharu.transform.position.x - MoveMapBox.transform.position.x);
        // 스즈미와 F로 상호작용
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
        //맵 이동 상호 작용
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
