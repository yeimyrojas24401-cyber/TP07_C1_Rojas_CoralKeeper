using UnityEngine;
using UnityEngine.UI;

public class BtnClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private Button button;
    private void Awake()
    {
        button.onClick.AddListener(PlayClickSound);
    }
    private void OnDestroy()
    {
        button.onClick.RemoveListener(PlayClickSound);
    }
    private void PlayClickSound()
    {
        audioSource.PlayOneShot(clickClip);
    }
}
