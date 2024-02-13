using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Canvas canvas;
    void Start()
    {
        resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
        if (canvas != null)
        {
            canvas.worldCamera = Camera.main;
        }
        else
        {
            Debug.LogError("Canvas component not assigned.");
        }
    }

    public void SetResolution_full()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
    }
    public void SetResolution_1920x1080()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }
    public void SetResolution_1280x720()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }
    public void ChangeResolution(int value)
    {
        switch (value)
        {
            case 0: // Full Screen
                SetResolution_full();
                Debug.Log(value);
                break;
            case 1: // 1920x1080
                Debug.Log(value);
                SetResolution_1920x1080();
                break;
            case 2: // 1280x720
                Debug.Log(value);
                SetResolution_1280x720();
                break;
            default:
                Debug.LogError("Invalid resolution option.");
                break;
        }
    }
    public void CloseSetting()
    {
        Destroy(gameObject);
    }
    public void ToStartMenu()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("StartMenu");
    }
}
