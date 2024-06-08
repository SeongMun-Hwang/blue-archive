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
            DontDestroyOnLoad(gameObject); // �� ��ȯ�ÿ��� �ı����� �ʵ��� ����
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ� �ı�
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
