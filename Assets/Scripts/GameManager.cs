using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글턴 인스턴스
    public int NumberOfInteractWithSuzumi = 0;
    public int NumberOfInteractWithLeisa = 0;
    private bool isMenuOpen = false; //로드세이브 창 열기 

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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("StartMenu");
            Debug.Log("working");

            //환경설정 리소스 로드
            //GameObject settingWindow = Resources.Load<GameObject>("SettingCanvas");
            //Instantiate(settingWindow);
            if (!isMenuOpen)
            {
                // LoadSave 씬을 불러오고 상태를 업데이트
                SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
                isMenuOpen = true;
            }
            else
            {
                // LoadSave 씬을 닫고 상태를 업데이트
                SceneManager.UnloadSceneAsync("Menu");
                isMenuOpen = false;
            }
        }
    }
    public void ChangeScene(string sceneName)
    {
        SaveCurrentSceneName();
        PlayerPrefs.SetString("SceneToLoad", sceneName);
        SceneManager.LoadScene("Loading");
    }

    private void SaveCurrentSceneName()
    {
        // 현재 씬 이름을 저장
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }
}
