using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Button[] buttons; // 에디터에서 할당
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
        // 입력에 따라 selectedIndex를 업데이트합니다.
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // 이전 하이라이트를 제거합니다.
            buttons[selectedIndex].GetComponent<Image>().color = originalColors[selectedIndex];
            buttons[selectedIndex].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            // W키는 위로 이동, S키는 아래로 이동
            selectedIndex += Input.GetKeyDown(KeyCode.UpArrow) ? -1 : 1;

            // 인덱스가 범위를 벗어나지 않게 합니다.
            if (selectedIndex < 0) selectedIndex = buttons.Length - 1;
            else if (selectedIndex > buttons.Length - 1) selectedIndex = 0;

            // 새로운 버튼을 하이라이트합니다.
            HighlightButton(selectedIndex);
        }

        // 선택된 버튼에 대한 클릭 이벤트를 발생시킵니다.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // A나 D키가 눌리면 해당 버튼의 onClick 이벤트를 호출합니다.
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
