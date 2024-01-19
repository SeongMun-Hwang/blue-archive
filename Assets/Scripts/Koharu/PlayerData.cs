using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance; // �̱��� �ν��Ͻ�

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
    private string currentSaveSlot = "SaveSlot1"; // �⺻ ���̺� ����

    void Update()
    {
        // ���̺� ���� ���� (��: 1, 2, 3�� Ű)
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

            // ���̺� �� �ε�
        if (Input.GetKeyDown(KeyCode.F5)) SavePlayerData();
        if (Input.GetKeyDown(KeyCode.L)) LoadPlayerData();
    }

    public void SavePlayerData()
    {
        //���� �ð� ����
        string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        PlayerPrefs.SetString(currentSaveSlot + "_DateTime", dateTime);
        // ���̺� ���Կ� ���� Ű�� �ٸ��� ����
        PlayerPrefs.SetString(currentSaveSlot + "_SceneName", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat(currentSaveSlot + "_PlayerPositionX", transform.position.x);
        PlayerPrefs.SetFloat(currentSaveSlot + "_PlayerPositionY", transform.position.y);
        PlayerPrefs.Save();
        Debug.Log("���� �� : " + PlayerPrefs.GetString(currentSaveSlot + "_SceneName", "�������"));
        Debug.Log("���� X��ǥ : " + PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionX", 0));
        Debug.Log("���� Y��ǥ : " + PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionY", 0));
    }
    void LoadPlayerData()
    {
        // ���̺� ���Կ� ���� ������ �ҷ�����
        string sceneName = PlayerPrefs.GetString(currentSaveSlot + "_SceneName", "DefaultSceneName");
        float x = PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionX", 0);
        float y = PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionY", 0);
        Vector2 position = new Vector2(x, y);
        Debug.Log("���� �� : " + PlayerPrefs.GetString(currentSaveSlot + "_SceneName", "DefaultSceneName"));
        Debug.Log("���� X��ǥ : " + PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionX", 0));
        Debug.Log("���� Y��ǥ : " + PlayerPrefs.GetFloat(currentSaveSlot + "_PlayerPositionY", 0));
        // �� �ε� �� �÷��̾� ��ġ ����
        // SceneManager.LoadScene(sceneName);
        // transform.position = position;
    }
}
