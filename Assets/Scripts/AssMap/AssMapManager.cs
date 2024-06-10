using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssMapManager : MonoBehaviour
{
    public Image startImage;
    public float increaseTime;

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
    }
}
