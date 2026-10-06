using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] private CoralProgressSo coralProgress;
    [SerializeField] private LevelDataSo levelData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite restoredSprite;
    [SerializeField] private TMP_Text messageText;
    private bool restored;
    public event UnityAction OnReefRestored;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (restored) return;
        if (!other.TryGetComponent<PlayerMarker>(out _)) return;
        int missing = levelData.RequiredFragments - coralProgress.CollectedFragments;
        if (missing > 0)
        {
            messageText.text = $"Te faltan {missing} fragmentos";
            return;
        }
        else
        {
            restored = true;
            spriteRenderer.sprite = restoredSprite;
            OnReefRestored?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent<PlayerMarker>(out _)) return;
        messageText.text = "";
    }

}
