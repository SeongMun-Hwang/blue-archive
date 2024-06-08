using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    public AudioSource audioSource;

    public AudioClip StartMenu;
    public AudioClip LeisaMap;
    public AudioClip SuzumiMap;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환시에도 파괴되지 않도록 설정
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // 중복 인스턴스 파괴
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "StartMenu":
                audioSource.clip = StartMenu;
                break;
            case "LeisaMap":
                audioSource.clip = LeisaMap;
                break;
            case "SuzumiMap":
                audioSource.clip = SuzumiMap;
                break;
            default:
                Debug.Log("No audio clip is set for this scene");
                return; 
        }

        audioSource.Play(); 
    }
}
