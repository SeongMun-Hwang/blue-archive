using System.Collections;
using UnityEngine;
using TMPro;

public class SuzumiText : MonoBehaviour
{
    public TextMeshPro textDisplay;
    public string[] textCase = new string[2] {
        "�л��̽Ű���?\n�׷��ٸ� ��������...\n�㿡�� ���� �Ͱ��ϼ���.\n�ҷ��л��� �ƴ϶���.\n" ,
         "..............." ,
    };
    private string currentText = "";
    private float delay = 0.1f;
    private int interactedNumber = 0; //��ȣ�ۿ� Ƚ��
    private void OnEnable()
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
        textDisplay.text = "";
    }

    IEnumerator ShowText(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i + 1);
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
