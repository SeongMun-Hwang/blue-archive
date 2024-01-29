using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSaveManager : MonoBehaviour
{
    public Button saveSlot1;
    public Button saveSlot2;
    public Button saveSlot3;

    private Button[] buttons; // 버튼 배열
    private int selectedButtonIndex = 0; // 현재 선택된 버튼의 인덱스
    private Color originalColor;
    private Color selectedColor = Color.white; // 선택된 버튼의 색상

    public GameObject scaryHanako;

    void Start()
    {
        // 초기 색상 설정
        originalColor = saveSlot1.image.color;

        buttons = new Button[] { saveSlot1, saveSlot2, saveSlot3 };

        saveSlot1.GetComponentInChildren<TextMeshProUGUI>().text = "세이브 1\n" + PlayerPrefs.GetString("SaveSlot1_SceneName", "DefaultSceneName") + "\n" + PlayerPrefs.GetString("SaveSlot1_DateTime");
        saveSlot2.GetComponentInChildren<TextMeshProUGUI>().text = "세이브 2\n" + PlayerPrefs.GetString("SaveSlot2_SceneName", "DefaultSceneName") + "\n" + PlayerPrefs.GetString("SaveSlot2_DateTime");
        saveSlot3.GetComponentInChildren<TextMeshProUGUI>().text = "세이브 3\n" + PlayerPrefs.GetString("SaveSlot3_SceneName", "DefaultSceneName") + "\n" + PlayerPrefs.GetString("SaveSlot3_DateTime");

        buttons[selectedButtonIndex].image.color = selectedColor;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeSelectedButton(1); // 다음 버튼 선택
            if (PlayerData.Instance.saveslot < 3)
            {
                PlayerData.Instance.saveslot++;
            }
            else if (PlayerData.Instance.saveslot == 3)
            {
                PlayerData.Instance.saveslot = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeSelectedButton(-1); // 이전 버튼 선택
            if (PlayerData.Instance.saveslot > 1 )
            {
                PlayerData.Instance.saveslot--;
            }
            else if (PlayerData.Instance.saveslot == 1)
            {
                PlayerData.Instance.saveslot = 3;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Return))
        {
            // 이전 씬 이름을 가져옴
            string previousScene = PlayerPrefs.GetString("PreviousScene", "");

            if (previousScene == "StartMenu")
            {
                // StartMenu에서 왔을 경우, 저장된 씬 로드
                scaryHanako.SetActive(true);
                StartCoroutine(WaitForSoundAndLoadScene());
            }
            else
            {
                // StartMenu가 아닌 다른 씬에서 왔을 경우, 현재 상태 저장
                PlayerData.Instance.SavePlayerData();
            }
        }
    }
    void ChangeSelectedButton(int direction)
    {
        // 현재 선택된 버튼의 색상 복원
        buttons[selectedButtonIndex].image.color = originalColor;

        // 새로운 버튼 선택
        selectedButtonIndex += direction;
        if (selectedButtonIndex >= buttons.Length) selectedButtonIndex = 0;
        else if (selectedButtonIndex < 0) selectedButtonIndex = buttons.Length - 1;

        buttons[selectedButtonIndex].image.color = selectedColor;
    }

    IEnumerator WaitForSoundAndLoadScene()
    {
        // scaryHanako의 AudioSource 컴포넌트 가져오기
        AudioSource audioSource = scaryHanako.GetComponent<AudioSource>();

        // 효과음 재생
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();

            // 효과음 길이만큼 대기
            yield return new WaitForSeconds(audioSource.clip.length);
        }

        // 씬 로딩 함수 호출
        LoadSceneAfterLoading();
    }
    private void LoadSceneAfterLoading()
    {
        // 현재 선택된 저장 슬롯에 따라 씬 이름 저장
        string sceneToLoad = PlayerPrefs.GetString("SaveSlot" + (selectedButtonIndex + 1) + "_SceneName");

        // 로딩 씬을 불러오기 전에 씬 이름을 임시 저장
        PlayerPrefs.SetString("SceneToLoad", sceneToLoad);
        // 로딩 씬 불러오기
        SceneManager.LoadScene("Loading");
    }
}
