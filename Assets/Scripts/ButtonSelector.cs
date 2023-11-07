using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    public Button[] buttons; // 에디터에서 할당
    private int selectedIndex = 0;
    
    // 각 버튼의 원래 색상을 저장할 배열
    private Color[] originalColors;

    // 선택된 버튼의 하이라이트 색상
    public Color highlightColor = Color.yellow;

    void Start()
    {
        originalColors = new Color[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            // 버튼의 원래 색상을 저장합니다.
            originalColors[i] = buttons[i].GetComponent<Image>().color;
        }

        HighlightButton(selectedIndex); // 초기 선택된 버튼을 강조합니다.
    }

    void Update()
    {
        // 입력에 따라 selectedIndex를 업데이트합니다.
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            // 이전 하이라이트를 제거합니다.
            buttons[selectedIndex].GetComponent<Image>().color = originalColors[selectedIndex];

            // W키는 위로 이동, S키는 아래로 이동
            selectedIndex += Input.GetKeyDown(KeyCode.W) ? -1 : 1;

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

    // 선택된 버튼을 하이라이트하는 메소드
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
