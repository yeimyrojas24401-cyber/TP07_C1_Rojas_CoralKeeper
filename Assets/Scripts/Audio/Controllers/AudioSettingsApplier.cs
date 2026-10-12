using UnityEngine;

public class AudioSettingsApplier : MonoBehaviour
{
    [SerializeField] private AudioDataSo audioData;

    private void Start()
    {
        audioData.ApplyAllToMixer();    
    }
}
