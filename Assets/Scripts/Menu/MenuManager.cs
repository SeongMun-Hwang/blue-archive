using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button[] buttons; // �����Ϳ��� �Ҵ�
    private int selectedIndex = 0;
    private Color[] originalColors;
    public Color highlightColor = Color.yellow;

    // Start is called before the first frame update
    void Start()
    {
        originalColors = new Color[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            originalColors[i] = buttons[i].GetComponent<Image>().color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �Է¿� ���� selectedIndex�� ������Ʈ�մϴ�.
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // ���� ���̶���Ʈ�� �����մϴ�.
            buttons[selectedIndex].GetComponent<Image>().color = originalColors[selectedIndex];

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
    }
    void ContunueGame()
    {
        Destroy(gameObject);
    }
}
