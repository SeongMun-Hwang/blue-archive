using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // �̱��� �ν��Ͻ�

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
    private void OnEnable()
    {
        volumeSlider.value = SoundManager.Instance.audioSource.volume;
    }
    // ������ �����ϴ� �޼ҵ�
    public void SetVolume(float volume)
    {

        if (SoundManager.Instance.audioSource != null)
        {
            SoundManager.Instance.audioSource.volume = volume;
        }

    }
}
