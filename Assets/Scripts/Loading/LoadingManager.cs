using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    public TextMeshProUGUI Loading;
    public GameObject LoadingSpinner;
    private float rotateSpeed = 150.0f;
    void Update()
    {
        LoadingSpinner.transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }
}
