using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LoadSaveManager : MonoBehaviour
{
    public Button saveSlot1;
    public Button saveSlot2;
    public Button saveSlot3;

    private Button[] buttons; // ��ư �迭
    private int selectedButtonIndex = 0; // ���� ���õ� ��ư�� �ε���
    private Color originalColor;
    private Color selectedColor = Color.white; // ���õ� ��ư�� ����

    void Start()
    {
        // �ʱ� ���� ����
        originalColor = saveSlot1.image.color;
        buttons = new Button[] { saveSlot1, saveSlot2, saveSlot3 };

        saveSlot1.GetComponentInChildren<TextMeshProUGUI>().text = "���̺� 1\n" + PlayerPrefs.GetString("SaveSlot1_SceneName", "DefaultSceneName") + "\n" + PlayerPrefs.GetString("SaveSlot1_DateTime");
        saveSlot2.GetComponentInChildren<TextMeshProUGUI>().text = "���̺� 2\n" + PlayerPrefs.GetString("SaveSlot2_SceneName", "DefaultSceneName") + "\n" + PlayerPrefs.GetString("SaveSlot2_DateTime");
        saveSlot3.GetComponentInChildren<TextMeshProUGUI>().text = "���̺� 3\n" + PlayerPrefs.GetString("SaveSlot3_SceneName", "DefaultSceneName") + "\n" + PlayerPrefs.GetString("SaveSlot3_DateTime");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeSelectedButton(1); // ���� ��ư ����
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeSelectedButton(-1); // ���� ��ư ����
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("SaveSlot"+(selectedButtonIndex+1)+"_SceneName"));
        }
    }
    void ChangeSelectedButton(int direction)
    {
        // ���� ���õ� ��ư�� ���� ����
        buttons[selectedButtonIndex].image.color = originalColor;

        // ���ο� ��ư ����
        selectedButtonIndex += direction;
        if (selectedButtonIndex >= buttons.Length) selectedButtonIndex = 0;
        else if (selectedButtonIndex < 0) selectedButtonIndex = buttons.Length - 1;

        buttons[selectedButtonIndex].image.color = selectedColor;
    }
}
