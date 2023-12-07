using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    void Update()
    {
        // �÷��̾��� ��ġ�� �����Ϸ���, ���� ���, ����� �Է¿� �����Ͽ� �� �޼��带 ȣ���մϴ�.
        if (Input.GetKeyDown(KeyCode.S)) // S Ű�� ���� ����
        {
            SavePlayerData();
        }

        // ����� �����͸� �ҷ�������, �ٸ� Ű �Է¿� �����Ͽ� �� �޼��带 ȣ���� �� �ֽ��ϴ�.
        if (Input.GetKeyDown(KeyCode.L)) // L Ű�� ���� �ҷ�����
        {
            LoadPlayerData();
        }
    }

    void SavePlayerData()
    {
        // ���� �� �̸��� �÷��̾��� ��ġ ����
        PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("PlayerPositionX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", transform.position.y);
        PlayerPrefs.Save(); // ���� ���� ����
        Debug.Log("���� �� : " + PlayerPrefs.GetString("SceneName", "DefaultSceneName"));
        Debug.Log("���� X��ǥ : " + PlayerPrefs.GetFloat("PlayerPositionX", 0));
        Debug.Log("���� y��ǥ : " + PlayerPrefs.GetFloat("PlayerPositionY", 0));
    }

    void LoadPlayerData()
    {
        // ����� �����͸� �ҷ���
        string sceneName = PlayerPrefs.GetString("SceneName", "DefaultSceneName");
        float x = PlayerPrefs.GetFloat("PlayerPositionX", 0);
        float y = PlayerPrefs.GetFloat("PlayerPositionY", 0);
        Vector2 position = new Vector3(x, y);
        // ���⿡�� ���� �ҷ����� �÷��̾��� ��ġ�� �����ϴ� ������ �߰��� �� �ֽ��ϴ�.
        // ��: SceneManager.LoadScene(sceneName);
        // transform.position = position;
    }
}
