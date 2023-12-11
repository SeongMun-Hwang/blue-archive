using UnityEngine;
using UnityEngine.UI; // UI ��Ҹ� ����ϱ� ���� �߰�
using TMPro;

public class LoadSaveManager : MonoBehaviour
{
    // ���̺� ���Ժ� �� �̸��� ǥ���� Text UI ���
    public TextMeshProUGUI saveSlot1;
    public TextMeshProUGUI saveSlot2;
    public TextMeshProUGUI saveSlot3;

    // Start is called before the first frame update
    void Start()
    {
        // �� ���̺� ���Կ��� �� �̸��� �ҷ��� Text UI�� ǥ��
        saveSlot1.text = "���̺� 1\n"+PlayerPrefs.GetString("SaveSlot1_SceneName", "DefaultSceneName");
        saveSlot2.text = "���̺� 2\n" + PlayerPrefs.GetString("SaveSlot2_SceneName", "DefaultSceneName");
        saveSlot3.text = "���̺� 3\n" + PlayerPrefs.GetString("SaveSlot3_SceneName", "DefaultSceneName");
    }
}
