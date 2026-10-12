using TMPro;
using UnityEngine;

public class VolumePercentageText : MonoBehaviour
{
    [SerializeField] private AudioDataSo audioData;
    [SerializeField] private AudioChannel channel;
    [SerializeField] private TMP_Text percentageText;

    private void OnEnable()
    {
        Debug.Log($"{name} → data: {audioData}, text: {percentageText}", this);
        UpdateText(audioData.GetVolume(channel));
        switch(channel)
        {
            case AudioChannel.Master:
                audioData.OnMasterVolumeChanged += UpdateText;
                break;
            case AudioChannel.Background:
                audioData.OnBackgroundVolumeChanged += UpdateText;
                break;
            case AudioChannel.SFX:
                audioData.OnSfxVolumeChanged += UpdateText;
                break;
            case AudioChannel.UI:
                audioData.OnUiVolumeChanged += UpdateText;
                break;
        }
    }
    private void OnDisable()
    {
        switch(channel)
        {
            case AudioChannel.Master:
                audioData.OnMasterVolumeChanged -= UpdateText;
                break;
            case AudioChannel.Background:
                audioData.OnBackgroundVolumeChanged -= UpdateText;
                break;
            case AudioChannel.SFX:
                audioData.OnSfxVolumeChanged -= UpdateText;
                break;
            case AudioChannel.UI:
                audioData.OnUiVolumeChanged -= UpdateText;
                break;
        }
    }
    private void UpdateText(float value)
    {
        int percentage = Mathf.RoundToInt(value * 100f);
        percentageText.text = $"{percentage}%";
    }
}
