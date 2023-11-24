using System.Collections;
using UnityEngine;
using TMPro;

public class SuzumiText : MonoBehaviour
{
    public TextMeshPro textDisplay;
    public string[] textCase = new string[2] {
        "학생이신가요?\n그렇다면 괜찮지만...\n밤에는 빨리 귀가하세요.\n불량학생이 아니라면요.\n" ,
         "..............." ,
    };
    private string currentText = "";
    private float delay = 0.1f;
    private int interactedNumber = 0; //상호작용 횟수
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
