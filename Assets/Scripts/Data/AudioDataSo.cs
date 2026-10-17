
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "AudioData", menuName = "Data/Game/AudioData")]

public class AudioDataSo : ScriptableObject
{
    [SerializeField, Range(0, 1)] private float masterVolume = 1f;
    public float MasterVolume => masterVolume;
    [SerializeField, Range(0, 1)] private float backgroundVolume = 0.4f;
    public float BackgroundVolume => backgroundVolume;
    [SerializeField, Range(0, 1)] private float sfxVolume = 1f;
    public float SfxVolume => sfxVolume;
    [SerializeField, Range(0, 1)] private float uiVolume = 1f;
    public float UiVolume => uiVolume;

    [SerializeField] private AudioMixer mixer;

    private const string MasterKey = "VolumeMaster";
    private const string BackgroundKey = "VolumeBackground";
    private const string SFXKey = "VolumeSFX";
    private const string UIKey = "VolumeUI";

    private const float MinVolume = 0.0001f;

    public event UnityAction<float> OnMasterVolumeChanged;
    public event UnityAction<float> OnBackgroundVolumeChanged;
    public event UnityAction<float> OnSfxVolumeChanged;
    public event UnityAction<float> OnUiVolumeChanged;
    private void OnEnable()
    {
        LoadVolumeSettings();
    }
    public void SetVolumeOf(AudioChannel channel, float volume)
    {
        switch (channel)
        {
            case AudioChannel.Master:
                SetVolume(ref masterVolume, volume, MasterKey, OnMasterVolumeChanged);
                break;
            case AudioChannel.Background:
                SetVolume(ref backgroundVolume, volume, BackgroundKey, OnBackgroundVolumeChanged);
                break;
            case AudioChannel.SFX:
                SetVolume(ref sfxVolume, volume, SFXKey, OnSfxVolumeChanged);
                break;
            case AudioChannel.UI:
                SetVolume(ref uiVolume, volume, UIKey, OnUiVolumeChanged);
                break;
        }
    }
    private void SetVolume(ref float volumeField, float volume, string key, UnityAction<float> onVolumeChanged)
    {
        volumeField = volume;

        ApplyToMixer(key, volume);
        onVolumeChanged?.Invoke(volume);
        SaveVolumeSettings();
    }

    private void ApplyToMixer(string key, float value)
    {
        mixer.SetFloat(key, Mathf.Log10(Mathf.Max(value, MinVolume)) * 20f);
    }
    private void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat(MasterKey, masterVolume);
        PlayerPrefs.SetFloat(BackgroundKey, backgroundVolume);
        PlayerPrefs.SetFloat(SFXKey, sfxVolume);
        PlayerPrefs.SetFloat(UIKey, uiVolume);

        PlayerPrefs.Save();
    }
    private void LoadVolumeSettings()
    {
        masterVolume = PlayerPrefs.GetFloat(MasterKey, 1f);
        backgroundVolume = PlayerPrefs.GetFloat(BackgroundKey, 0.4f);
        sfxVolume = PlayerPrefs.GetFloat(SFXKey, 1f);
        uiVolume = PlayerPrefs.GetFloat(UIKey, 1f);
    }
    public void ApplyAllToMixer()
    {
        ApplyToMixer(MasterKey, masterVolume);
        ApplyToMixer(BackgroundKey, backgroundVolume);
        ApplyToMixer(SFXKey, sfxVolume);
        ApplyToMixer(UIKey, uiVolume);
    }
    public float GetVolume(AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.Master: return MasterVolume;
            case AudioChannel.Background: return BackgroundVolume;
            case AudioChannel.SFX: return SfxVolume;
            case AudioChannel.UI: return UiVolume;
            default: return 1f;
        }

    }
}
