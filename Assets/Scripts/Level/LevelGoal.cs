using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] private CoralProgressSo coralProgress;
    [SerializeField] private LevelDataSo levelData;
    [SerializeField] private TMP_Text messageText;
    private bool restored;
    private bool isPlayerInside = false;
    public event UnityAction OnReefRestored;

    private void Awake()
    {
        coralProgress.OnFragmentsChanged += HandleFragmentsChanged;
    }
    private void OnDestroy()
    {
        coralProgress.OnFragmentsChanged -= HandleFragmentsChanged;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<PlayerMarker>(out _)) 
            return;

        isPlayerInside = true;
        TryRestoreReef();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent<PlayerMarker>(out _)) 
            return;

        isPlayerInside = false;
        messageText.text = "";
    }

    private void HandleFragmentsChanged(int count)
    {
        TryRestoreReef();
    }

    private void TryRestoreReef()
    {
        if (restored || !isPlayerInside)
            return;

        int missing = levelData.RequiredFragments - coralProgress.CollectedFragments;

        if (missing > 0)
        {
            messageText.text = $"{missing} fragments missing";
            return;
        }

        restored = true;
        messageText.text = "";
        OnReefRestored?.Invoke();
    }
}
