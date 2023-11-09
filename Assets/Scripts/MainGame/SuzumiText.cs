using System.Collections;
using UnityEngine;
using TMPro;

public class SuzumiText : MonoBehaviour
{
    public TextMeshPro textDisplay;
    public string fullText = "�л��̽Ű���?\n �׷��ٸ� ��������...\n �㿡�� ���� �Ͱ��ϼ���.\n" +
        "�ҷ��л��� �ƴ϶���.\n";
    private string currentText = "";
    private float delay = 0.1f;

    private void OnEnable()
    {
        StartCoroutine(ShowText());
    }
    private void OnDisable()
    {
        textDisplay.text = "";
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
