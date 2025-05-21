using Redacted.Component;
using UnityEngine;

namespace Redacted.Component.Setting
{
    [AddComponentMenu("Redacted/Setting/SettingManaager")]
    [DisallowMultipleComponent]
    public sealed class SettingsManager : RDCTStaticClasses
    {
        public static SettingsManager Instance { get; private set; }
        public Settings settings;
        private void Awake()
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

            OnCreated();
        }

        public override void OnCreated()
        {
            settings.DisplaySettings.ResolutionIndex = new Resolution
            {
                width = Screen.currentResolution.width,
                height = Screen.currentResolution.height,
            };

            Debug.Log($"Resolution: {settings.DisplaySettings.ResolutionIndex.width} x {settings.DisplaySettings.ResolutionIndex.height}");
        }

        private void Start()
        {
            if (!LoadSettings())
            {
                ResetSettings();
            }
        }

        public void ApplySetting()
        {
            SaveSettings();
        }

        public void LoadSetting()
        {
            LoadSettings();
        }

        public void ResetSetting()
        {
            ResetSettings();
        }

        public bool SaveSettings()
        {
            if (settings == null)
                return false;

            string json = JsonUtility.ToJson(settings);

            string key = $"Settings_{System.DateTime.UtcNow.Ticks}";
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.SetString("Settings_Latest", key);
            PlayerPrefs.Save();

#if REDACTED_DEBUG
            Debug.Log($"Settings saved with key: {key}");
#endif

            return true;
        }

        public bool LoadSettings()
        {
            string latestKey = PlayerPrefs.GetString("Settings_Latest", null);

#if REDACTED_DEBUG
            Debug.Log($"Latest settings key: {latestKey}");
#endif

            if (string.IsNullOrEmpty(latestKey))
                return false;

            string json = PlayerPrefs.GetString(latestKey, null);
            if (string.IsNullOrEmpty(json))
                return false;

            settings = JsonUtility.FromJson<Settings>(json);
            return true;
        }

        public bool ResetSettings()
        {
            settings = new Settings
            {
                DisplaySettings = new RedactedDisplaySetting(),
                VideoSettings = new RedactedVideoSetting(),
                AudioSettings = new RedactedAudioSetting()
            };
            settings.DisplaySettings.ResolutionIndex = new Resolution
            {
                width = Screen.currentResolution.width,
                height = Screen.currentResolution.height,
            };
            settings.VideoSettings.QualityIndex = VideoQuality.Medium;
            settings.DisplaySettings.IsFullScreen = Screen.fullScreen;
            settings.DisplaySettings.RefreshRate = Screen.currentResolution.refreshRateRatio.numerator / Screen.currentResolution.refreshRateRatio.denominator;
            settings.AudioSettings.BGMVolume = 100;
            settings.AudioSettings.SFXVolume = 100;
            settings.AudioSettings.VOVolume = 100;
            settings.AudioSettings.UIVolume = 100;
            return true;
        }
    }

    [System.Serializable]
    public sealed class Settings
    {
        public RedactedDisplaySetting DisplaySettings;
        public RedactedVideoSetting VideoSettings;
        public RedactedAudioSetting AudioSettings;
    }

    [System.Serializable]
    public sealed class RedactedAudioSetting
    {
        [Range(0, 100)] public int BGMVolume = 100;
        [Range(0, 100)] public int SFXVolume = 100;
        [Range(0, 100)] public int VOVolume = 100;
        [Range(0, 100)] public int UIVolume = 100;
    }

    [System.Serializable]
    public sealed class RedactedVideoSetting
    {
        public VideoQuality QualityIndex;
    }

    [System.Serializable]
    public sealed class RedactedDisplaySetting
    {
        public Resolution ResolutionIndex;
        public float RefreshRate;
        public bool IsFullScreen;
    }

    public enum VideoQuality
    {
        Low,
        Medium,
        High,
        Ultra,
        Custom
    }
}
