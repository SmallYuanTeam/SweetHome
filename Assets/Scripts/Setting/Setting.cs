using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public SceneManagerHelper sceneManagerHelper;
    public AudioManager audioManager;
    public HighlightController highlightController;
    public GameObject mainSettingPanel;
    public GameObject moreSettingsPanel;
    public GameObject volumePanel;
    public Player player;
    public Slider bgmSlider;
    public Slider seSlider;
    public Slider meSlider;
    public GameObject textSpeedPanel;
    public GameObject PausePanel;
    public List<Image> Shadows;

    void Start()
    {
        sceneManagerHelper = FindObjectOfType<SceneManagerHelper>();
        mainSettingPanel.SetActive(false);
        moreSettingsPanel.SetActive(false);
        volumePanel.SetActive(false);
        textSpeedPanel.SetActive(false);
        PausePanel.SetActive(false);
        
        Shadows = FindImagesInChildren(transform, "Shadow").ToList();
        if (bgmSlider != null)
        {
            audioManager.SetVolume(LoadBGMVolumeSettings());
            bgmSlider.value = LoadBGMVolumeSettings();
            // 添加滑條事件監聽
            bgmSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }
    IEnumerable<Image> FindImagesInChildren(Transform parent, string name)
    {
        List<Image> foundImages = new List<Image>();

        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                Image image = child.GetComponent<Image>();
                if (image != null) foundImages.Add(image);
            }
            // 递归查找子对象
            foundImages.AddRange(FindImagesInChildren(child, name));
        }

        return foundImages;
    }
    public void ShowMoreSettings()
    {
        mainSettingPanel.SetActive(false);
        moreSettingsPanel.SetActive(true);
        Shadows.ForEach(s => s.color = new Color(s.color.r, s.color.g, s.color.b, 0));
    }

    public void ShowVolumeSettings()
    {
        moreSettingsPanel.SetActive(false);
        volumePanel.SetActive(true);
        Shadows.ForEach(s => s.color = new Color(s.color.r, s.color.g, s.color.b, 0));
    }

    public void ShowTextSpeedSettings()
    {
        moreSettingsPanel.SetActive(false);
        textSpeedPanel.SetActive(true);
        Shadows.ForEach(s => s.color = new Color(s.color.r, s.color.g, s.color.b, 0));
    }

    public void ReturnToMainSetting()
    {
        moreSettingsPanel.SetActive(false);
        volumePanel.SetActive(false);
        textSpeedPanel.SetActive(false);
        mainSettingPanel.SetActive(true);
        PausePanel.SetActive(true);
        Shadows.ForEach(s => s.color = new Color(s.color.r, s.color.g, s.color.b, 0f));
    }
    public void CloseGame()
    {
        List<string> MainMenuToLoad = new List<string> {"MainMenu"};
        sceneManagerHelper.LoadSceneWithTransition(MainMenuToLoad);
        ReturnToGame();
    }
    public void ReturnToGame()
    {
        moreSettingsPanel.SetActive(false);
        volumePanel.SetActive(false);
        textSpeedPanel.SetActive(false);
        mainSettingPanel.SetActive(false);
        PausePanel.SetActive(false);
        Shadows.ForEach(s => s.color = new Color(s.color.r, s.color.g, s.color.b, 0));
    }
    // 保存音量設定
    public void SaveVolumeSettings(float volume)
    {
        player.BGMVolume = volume;
    }

    // 加載音量設定
    public float LoadBGMVolumeSettings()
    {
        return player.BGMVolume;
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

        SaveVolumeSettings(value);
    }
}
