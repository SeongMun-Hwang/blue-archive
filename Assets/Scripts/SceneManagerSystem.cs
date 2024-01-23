using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSystem : MonoBehaviour
{
    public static SceneManagerSystem Instance; // �̱��� �ν��Ͻ�

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
        // ���� �� �̸��� ����
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }
}
