using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LoadSaveManager : MonoBehaviour
{
    public Button saveSlot1;
    public Button saveSlot2;
    public Button saveSlot3;

    private Button[] buttons; // 버튼 배열
    private int selectedButtonIndex = 0; // 현재 선택된 버튼의 인덱스
    private Color originalColor;
    private Color selectedColor = Color.white; // 선택된 버튼의 색상

    void Start()
    {
        // 초기 색상 설정
        originalColor = saveSlot1.image.color;
        buttons = new Button[] { saveSlot1, saveSlot2, saveSlot3 };

        saveSlot1.GetComponentInChildren<TextMeshProUGUI>().text = "세이브 1\n" + PlayerPrefs.GetString("SaveSlot1_SceneName", "DefaultSceneName") + "\n" + PlayerPrefs.GetString("SaveSlot1_DateTime");
        saveSlot2.GetComponentInChildren<TextMeshProUGUI>().text = "세이브 2\n" + PlayerPrefs.GetString("SaveSlot2_SceneName", "DefaultSceneName") + "\n" + PlayerPrefs.GetString("SaveSlot2_DateTime");
        saveSlot3.GetComponentInChildren<TextMeshProUGUI>().text = "세이브 3\n" + PlayerPrefs.GetString("SaveSlot3_SceneName", "DefaultSceneName") + "\n" + PlayerPrefs.GetString("SaveSlot3_DateTime");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeSelectedButton(1); // 다음 버튼 선택
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeSelectedButton(-1); // 이전 버튼 선택
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("SaveSlot"+(selectedButtonIndex+1)+"_SceneName"));
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
}
