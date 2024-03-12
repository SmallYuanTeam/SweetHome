using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource backgroundMusicSource;
    private AudioSource soundEffectSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        // 假設這個 GameObject 有一個 AudioSource 用於背景音樂
        backgroundMusicSource = GetComponent<AudioSource>();
    }

    public void SetVolume(float volume)
    {
        backgroundMusicSource.volume = volume;

        // 如果有多個音源，也可以在這裡設置它們的音量
    }

    // 用於播放效果音的方法
    public void PlaySoundEffect(AudioClip clip, float volume = 1.0f)
    {
        // 這裡為了簡化示例，我們每次播放效果音時都會創建一個新的 AudioSource
        // 在實際應用中，你可能會想重用或者池化 AudioSource 來優化性能
        soundEffectSource = gameObject.AddComponent<AudioSource>();
        soundEffectSource.clip = clip;
        soundEffectSource.volume = volume;
        soundEffectSource.Play();

        // 自動銷毀 AudioSource 組件一旦音頻播放完畢
        Destroy(soundEffectSource, clip.length);
    }

    // 例如，當用戶調整音量設定時調用
    public void UpdateVolumeSettings(float musicVolume, float effectsVolume)
    {
        backgroundMusicSource.volume = musicVolume;

        // 假設你保存了所有效果音的 AudioSource，你可以這樣設置它們的音量
        // soundEffectSource.volume = effectsVolume;
    }
}
