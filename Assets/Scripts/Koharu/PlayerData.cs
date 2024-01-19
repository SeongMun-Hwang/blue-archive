using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance; // 싱글턴 인스턴스

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private string currentSaveSlot = "SaveSlot1"; // 기본 세이브 슬롯

    void Update()
    {
        // 세이브 슬롯 선택 (예: 1, 2, 3번 키)
        if (Input.GetKeyDown(KeyCode.Alpha1)) { 
            currentSaveSlot = "SaveSlot1";
            Debug.Log("SaveSlot1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSaveSlot = "SaveSlot2";
            Debug.Log("SaveSlot2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSaveSlot = "SaveSlot3";
            Debug.Log("SaveSlot3");
        }

            // 세이브 및 로드
        if (Input.GetKeyDown(KeyCode.F5)) SavePlayerData();
        if (Input.GetKeyDown(KeyCode.L)) LoadPlayerData();
    }

    public void SavePlayerData()
    {
        //현재 시간 저장
        string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        PlayerPrefs.SetString(currentSaveSlot + "_DateTime", dateTime);
        // 세이브 슬롯에 따라 키를 다르게 설정
        PlayerPrefs.SetString(currentSaveSlot + "_SceneName", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat(currentSaveSlot + "_PlayerPositionX", transform.position.x);
        PlayerPrefs.SetFloat(currentSaveSlot + "_PlayerPositionY", transform.position.y);
        PlayerPrefs.Save();
        Debug.Log("현재 씬 : " + PlayerPrefs.GetString(currentSaveSlot + "_SceneName", "비어있음"));
        Debug.Log("현재 X좌표 : " + PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionX", 0));
        Debug.Log("현재 Y좌표 : " + PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionY", 0));
    }
    void LoadPlayerData()
    {
        // 세이브 슬롯에 따라 데이터 불러오기
        string sceneName = PlayerPrefs.GetString(currentSaveSlot + "_SceneName", "DefaultSceneName");
        float x = PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionX", 0);
        float y = PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionY", 0);
        Vector2 position = new Vector2(x, y);
        Debug.Log("현재 씬 : " + PlayerPrefs.GetString(currentSaveSlot + "_SceneName", "DefaultSceneName"));
        Debug.Log("현재 X좌표 : " + PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionX", 0));
        Debug.Log("현재 Y좌표 : " + PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionY", 0));
        // 씬 로드 및 플레이어 위치 설정
        // SceneManager.LoadScene(sceneName);
        // transform.position = position;
    }
}
