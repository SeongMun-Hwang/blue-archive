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
        float duration = 25.6f; // 전체 지속 시간
        float currentTime = 0f;

        while (currentTime < duration)
        {
            float alpha = currentTime / duration; // 현재 시간을 기준으로 알파값 계산
            startImage.color = new Color(startImage.color.r, startImage.color.g, startImage.color.b, alpha);
            currentTime += increaseTime; // 매 루프마다 시간 증가
            yield return new WaitForSeconds(0.1f);
        }
        startImage.color = new Color(startImage.color.r, startImage.color.g, startImage.color.b, 1);
    }
}
