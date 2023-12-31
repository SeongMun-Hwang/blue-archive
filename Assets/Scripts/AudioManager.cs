using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // 싱글톤 인스턴스

    public AudioSource[] audioSources; // 오디오 소스 배열
    public Slider volumeSlider;

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
    }
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }
    // 볼륨을 설정하는 메소드
    public void SetVolume(float volume)
    {
        foreach (AudioSource source in audioSources)
        {
            if (source != null)
            {
                source.volume = volume;
            }
        }
    }
}
