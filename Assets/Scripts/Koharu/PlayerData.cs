using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    void Update()
    {
        // 플레이어의 위치를 저장하려면, 예를 들어, 사용자 입력에 응답하여 이 메서드를 호출합니다.
        if (Input.GetKeyDown(KeyCode.S)) // S 키를 눌러 저장
        {
            SavePlayerData();
        }

        // 저장된 데이터를 불러오려면, 다른 키 입력에 응답하여 이 메서드를 호출할 수 있습니다.
        if (Input.GetKeyDown(KeyCode.L)) // L 키를 눌러 불러오기
        {
            LoadPlayerData();
        }
    }

    void SavePlayerData()
    {
        // 현재 씬 이름과 플레이어의 위치 저장
        PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("PlayerPositionX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", transform.position.y);
        PlayerPrefs.Save(); // 변경 사항 저장
        Debug.Log("현재 씬 : " + PlayerPrefs.GetString("SceneName", "DefaultSceneName"));
        Debug.Log("현재 X좌표 : " + PlayerPrefs.GetFloat("PlayerPositionX", 0));
        Debug.Log("현재 y좌표 : " + PlayerPrefs.GetFloat("PlayerPositionY", 0));
    }

    void LoadPlayerData()
    {
        // 저장된 데이터를 불러옴
        string sceneName = PlayerPrefs.GetString("SceneName", "DefaultSceneName");
        float x = PlayerPrefs.GetFloat("PlayerPositionX", 0);
        float y = PlayerPrefs.GetFloat("PlayerPositionY", 0);
        Vector2 position = new Vector3(x, y);
        // 여기에서 씬을 불러오고 플레이어의 위치를 설정하는 로직을 추가할 수 있습니다.
        // 예: SceneManager.LoadScene(sceneName);
        // transform.position = position;
    }
}
