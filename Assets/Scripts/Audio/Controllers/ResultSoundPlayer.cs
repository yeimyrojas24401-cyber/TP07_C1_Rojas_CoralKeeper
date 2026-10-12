using UnityEngine;

public class ResultSoundPlayer : MonoBehaviour
{
    [SerializeField] private GameResultSo dataGameResult;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioClip loseClip;

    private void Start()
    {
        AudioClip clip = dataGameResult.Won ? winClip : loseClip;
        audioSource.clip = clip;
        audioSource.Play();

    }
}
