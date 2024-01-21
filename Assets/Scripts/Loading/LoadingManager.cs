using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public TextMeshProUGUI Loading;
    public GameObject LoadingSpinner;
    private float rotateSpeed = 150.0f;
    void Update()
    {
        LoadingSpinner.transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 저장된 씬 이름 불러오기
        string sceneToLoad = PlayerPrefs.GetString("SceneToLoad");

        // 해당 씬 로드
        SceneManagerSystem.Instance.ChangeScene(sceneToLoad);
    }
}
