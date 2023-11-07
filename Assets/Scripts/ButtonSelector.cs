using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    public Button[] buttons; // �����Ϳ��� �Ҵ�
    private int selectedIndex = 0;
    
    // �� ��ư�� ���� ������ ������ �迭
    private Color[] originalColors;

    // ���õ� ��ư�� ���̶���Ʈ ����
    public Color highlightColor = Color.yellow;

    void Start()
    {
        originalColors = new Color[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            // ��ư�� ���� ������ �����մϴ�.
            originalColors[i] = buttons[i].GetComponent<Image>().color;
        }

        HighlightButton(selectedIndex); // �ʱ� ���õ� ��ư�� �����մϴ�.
    }

    void Update()
    {
        // �Է¿� ���� selectedIndex�� ������Ʈ�մϴ�.
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            // ���� ���̶���Ʈ�� �����մϴ�.
            buttons[selectedIndex].GetComponent<Image>().color = originalColors[selectedIndex];

            // WŰ�� ���� �̵�, SŰ�� �Ʒ��� �̵�
            selectedIndex += Input.GetKeyDown(KeyCode.W) ? -1 : 1;

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

    // ���õ� ��ư�� ���̶���Ʈ�ϴ� �޼ҵ�
    void HighlightButton(int index)
    {
        buttons[index].GetComponent<Image>().color = highlightColor;
    }
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
