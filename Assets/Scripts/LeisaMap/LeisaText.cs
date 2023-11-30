using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeisaText : MonoBehaviour
{
    public TextMeshPro surpriseLeisaText;
    public string[] textCase = new string[2] {
        "���, ���!?\n��, ���ư�����!!\n�� ���� ���� �ȵſ�!\n" ,
         "�� ���� ���ص� �ȵſ�!" ,
    };
    private string currentText = "";
    private float delay = 0.1f;
    private int interactedNumber = 0; //��ȣ�ۿ� Ƚ��

    void OnEnable()
    {
        if (interactedNumber == 0)
        {
            StartCoroutine(ShowText(textCase[0]));
        }
        else if (interactedNumber > 0)
        {
            StartCoroutine(ShowText(textCase[1]));
        }
        interactedNumber++;
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
