using UnityEngine;

public class AudioSettingsApplier : MonoBehaviour
{
    [SerializeField] private AudioDataSo audioData;

    private void Start() //audiomixer ignora SetFloat antes del start
    {
        audioData.ApplyAllToMixer();    
    }
}
