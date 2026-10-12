using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    [SerializeField] private AudioDataSo audioData;
    [SerializeField] private AudioChannel channel;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = audioData.GetVolume(channel);
        slider.onValueChanged.AddListener(OnSliderVolumeChanged);
    }
    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(OnSliderVolumeChanged);
    }

    private void OnSliderVolumeChanged(float value)
    {
        switch(channel)
        {
            case AudioChannel.Master: audioData.SetMasterVolume(value);
                break;
            case AudioChannel.Background: audioData.SetBackgroundVolume(value);
                break;
            case AudioChannel.SFX: audioData.SetSfxVolume(value);
                break;
            case AudioChannel.UI: audioData.SetUiVolume(value);
                break;
        }
    }
}
