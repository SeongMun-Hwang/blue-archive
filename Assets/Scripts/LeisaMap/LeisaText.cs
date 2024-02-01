using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeisaText : MonoBehaviour
{
    public TextMeshPro surpriseLeisaText;
    public string[] textCase = new string[2] {
        "잠깐, 잠깐!?\n도, 돌아가세요!!\n이 앞은 가면 안돼요!\n" ,
         "몇 번을 말해도 안돼요!" ,
    };
    private string currentText = "";
    private float delay = 0.1f;

    void OnEnable()
    {
        if (GameManager.Instance.NumberOfInteractWithLeisa == 0)
        {
            StartCoroutine(ShowText(textCase[0]));
        }
        else if (GameManager.Instance.NumberOfInteractWithLeisa > 0)
        {
            StartCoroutine(ShowText(textCase[1]));
        }
        GameManager.Instance.NumberOfInteractWithLeisa++;
    }
    private void OnDisable()
    {
        surpriseLeisaText.text = "";
    }
    IEnumerator ShowText(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i + 1);
            surpriseLeisaText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
