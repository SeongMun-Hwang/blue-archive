using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Button[] buttons; // �����Ϳ��� �Ҵ�
    private int selectedIndex = 0;
    private Color[] originalColors;
    public Color highlightColor = Color.white;
    public Color highlightText = Color.black;
    public Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        originalColors = new Color[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            originalColors[i] = buttons[i].GetComponent<Image>().color;
        }
        HighlightButton(selectedIndex);
    }

    // Update is called once per frame
    void Update()
    {
        // �Է¿� ���� selectedIndex�� ������Ʈ�մϴ�.
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // ���� ���̶���Ʈ�� �����մϴ�.
            buttons[selectedIndex].GetComponent<Image>().color = originalColors[selectedIndex];
            buttons[selectedIndex].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            // WŰ�� ���� �̵�, SŰ�� �Ʒ��� �̵�
            selectedIndex += Input.GetKeyDown(KeyCode.UpArrow) ? -1 : 1;

            // �ε����� ������ ����� �ʰ� �մϴ�.
            if (selectedIndex < 0) selectedIndex = buttons.Length - 1;
            else if (selectedIndex > buttons.Length - 1) selectedIndex = 0;

            // ���ο� ��ư�� ���̶���Ʈ�մϴ�.
            HighlightButton(selectedIndex);
        }

        // ���õ� ��ư�� ���� Ŭ�� �̺�Ʈ�� �߻���ŵ�ϴ�.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // A�� DŰ�� ������ �ش� ��ư�� onClick �̺�Ʈ�� ȣ���մϴ�.
            buttons[selectedIndex].onClick.Invoke();
        }
    }
    void HighlightButton(int index)
    {
        buttons[index].GetComponent<Image>().color = highlightColor;
        buttons[index].GetComponentInChildren<TextMeshProUGUI>().color = highlightText;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("LoadSave", LoadSceneMode.Additive);
    }
    public void ContunueGame()
    {
        Destroy(gameObject);
    }
    public void Setting()
    {
        SceneManager.LoadScene("Setting", LoadSceneMode.Additive);
    }
}
