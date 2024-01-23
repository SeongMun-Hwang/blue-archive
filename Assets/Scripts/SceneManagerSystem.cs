using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSystem : MonoBehaviour
{
    public static SceneManagerSystem Instance; // 싱글턴 인스턴스

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
