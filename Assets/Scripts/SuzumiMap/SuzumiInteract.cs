using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스즈미와 상호작용을 관리하는 코드
public class SuzumiInteract : MonoBehaviour
{
    public GameObject ClosedSuzumi;
    public GameObject OpenedSuzumi;
    public GameObject Koharu;
    public GameObject InteractBox;
    public float interactDistance; //코하루와 스즈미 거리

    public void Update()
    {
        float distanceToSuzumi = Mathf.Abs(Koharu.transform.position.x - ClosedSuzumi.transform.position.x);
        // F로 상호작용
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
