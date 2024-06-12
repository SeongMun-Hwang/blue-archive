using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AssMapManager : MonoBehaviour
{
    public Image startImage;
    public float increaseTime;
    public TextMeshProUGUI[] textBubble;
    private string currentText = "";
    private float delay = 0.1f;

    private string[] firstScene = 
    {
        "���̸�, �ֹ��� ������ �� �� ����.",
        "��... ������ ���� �� ����",
        "�׷� ���� ������!"
    };
    void Start()
    {
        StartCoroutine(SceneStart());
    }

    IEnumerator SceneStart()
    {
        float duration = 25.6f; // ��ü ���� �ð�
        float currentTime = 0f;

        while (currentTime < duration)
        {
            float alpha = currentTime / duration; // ���� �ð��� �������� ���İ� ���
            startImage.color = new Color(startImage.color.r, startImage.color.g, startImage.color.b, alpha);
            currentTime += increaseTime; // �� �������� �ð� ����
            yield return new WaitForSeconds(0.1f);
        }
        startImage.color = new Color(startImage.color.r, startImage.color.g, startImage.color.b, 1);
        StartCoroutine(FirstScene());
    }
    IEnumerator FirstScene()
    {
        for(int j=0;j<textBubble.Length;j++)
        {
            textBubble[j].transform.parent.gameObject.SetActive(true);
            for (int i = 0; i < firstScene[j].Length; i++)
            {
                currentText = firstScene[j].Substring(0, i + 1);
                textBubble[j].text = currentText;
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(1);
            textBubble[j].transform.parent.gameObject.SetActive(false);
        }
    }
}
