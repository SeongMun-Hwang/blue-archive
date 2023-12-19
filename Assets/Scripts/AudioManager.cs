using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // �̱��� �ν��Ͻ�

    public AudioSource[] audioSources; // ����� �ҽ� �迭
    public Slider volumeSlider;

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
    }
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }
    // ������ �����ϴ� �޼ҵ�
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
