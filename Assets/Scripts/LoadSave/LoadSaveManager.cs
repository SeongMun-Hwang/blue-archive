using UnityEngine;
using UnityEngine.UI; // UI 요소를 사용하기 위해 추가
using TMPro;

public class LoadSaveManager : MonoBehaviour
{
    // 세이브 슬롯별 씬 이름을 표시할 Text UI 요소
    public TextMeshProUGUI saveSlot1;
    public TextMeshProUGUI saveSlot2;
    public TextMeshProUGUI saveSlot3;

    // Start is called before the first frame update
    void Start()
    {
        // 각 세이브 슬롯에서 씬 이름을 불러와 Text UI에 표시
        saveSlot1.text = "세이브 1\n"+PlayerPrefs.GetString("SaveSlot1_SceneName", "DefaultSceneName");
        saveSlot2.text = "세이브 2\n" + PlayerPrefs.GetString("SaveSlot2_SceneName", "DefaultSceneName");
        saveSlot3.text = "세이브 3\n" + PlayerPrefs.GetString("SaveSlot3_SceneName", "DefaultSceneName");
    }
}
