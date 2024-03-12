using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject mainSettingPanel;
    public GameObject moreSettingsPanel;
    public GameObject volumePanel;
    public Slider bgmSlider;
    public Slider seSlider;
    public Slider meSlider;
    public GameObject textSpeedPanel;
    public GameObject PausePanel;

    void Start()
    {
        mainSettingPanel.SetActive(false);
        moreSettingsPanel.SetActive(false);
        volumePanel.SetActive(false);
        textSpeedPanel.SetActive(false);
        PausePanel.SetActive(false);
        if (bgmSlider != null)
        {
            LoadBGMVolumeSettings();

            // 添加滑條事件監聽
            bgmSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }

    public void ShowMoreSettings()
    {
        mainSettingPanel.SetActive(false);
        moreSettingsPanel.SetActive(true);
    }

    public void ShowVolumeSettings()
    {
        moreSettingsPanel.SetActive(false);
        volumePanel.SetActive(true);
    }

    public void ShowTextSpeedSettings()
    {
        moreSettingsPanel.SetActive(false);
        textSpeedPanel.SetActive(true);
    }

    public void ReturnToMainSetting()
    {
        moreSettingsPanel.SetActive(false);
        volumePanel.SetActive(false);
        textSpeedPanel.SetActive(false);
        mainSettingPanel.SetActive(true);
        PausePanel.SetActive(true);
    }
    public void ReturnToGame()
    {
        moreSettingsPanel.SetActive(false);
        volumePanel.SetActive(false);
        textSpeedPanel.SetActive(false);
        mainSettingPanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    // 保存音量設定
    public void SaveVolumeSettings(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
    }

    // 加載音量設定
    public float LoadBGMVolumeSettings()
    {
        return PlayerPrefs.GetFloat("BGMVolume"); // 預設值為 1.0f
    }
    public void UpdateVolume(float volume)
    {
        // 假設有一個 AudioManager 控制遊戲音效
        AudioManager.Instance.SetVolume(volume);
    }
    void OnSliderValueChanged(float value)
    {
        // 更新 AudioManager 的音量設定
        if (audioManager != null)
        {
            audioManager.SetVolume(value);
        }

        // 保存新的音量值到 PlayerPrefs，以便下次遊戲啟動時能夠記住用戶的設定
        PlayerPrefs.SetFloat("BGMVolume", value);
    }
}
