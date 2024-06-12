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

    public Transform[] dessertsPosition;
    public GameObject[] desserts;

    private string[] firstScene = 
    {
        "아이리, 주문한 음식이 온 것 같아.",
        "음... 오늘은 몸이 안 좋네",
        "그럼 내가 먹을래!"
    };
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
        StartCoroutine(DessertCreator());
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
        StartCoroutine(DessertCreator());
    }
    IEnumerator DessertCreator()
    {
        GameObject currentDessert = null;

        while (true)
        {
            if (currentDessert != null)
            {
                Destroy(currentDessert); // 이전 디저트 파괴
            }

            // 새 디저트 생성
            currentDessert = Instantiate(desserts[Random.Range(0, desserts.Length)],
                dessertsPosition[Random.Range(0, dessertsPosition.Length)]);

            yield return new WaitForSeconds(2); // 적절한 대기 시간 부여
        }
    }

}
