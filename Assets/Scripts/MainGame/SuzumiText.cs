using System.Collections;
using UnityEngine;
using TMPro;

public class SuzumiText : MonoBehaviour
{
    public TextMeshPro textDisplay;
    public string fullText = "학생이신가요?\n 그렇다면 괜찮지만...\n 밤에는 빨리 귀가하세요.\n" +
        "불량학생이 아니라면요.\n";
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
