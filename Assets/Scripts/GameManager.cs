using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // �̱��� �ν��Ͻ�
    public int NumberOfInteractWithSuzumi = 0;
    public int NumberOfInteractWithLeisa = 0;
    private bool isMenuOpen = false; //�ε弼�̺� â ���� 

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

            //ȯ�漳�� ���ҽ� �ε�
            //GameObject settingWindow = Resources.Load<GameObject>("SettingCanvas");
            //Instantiate(settingWindow);
            if (!isMenuOpen)
            {
                // LoadSave ���� �ҷ����� ���¸� ������Ʈ
                SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
                isMenuOpen = true;
            }
            else
            {
                // LoadSave ���� �ݰ� ���¸� ������Ʈ
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
        // ���� �� �̸��� ����
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }
}
