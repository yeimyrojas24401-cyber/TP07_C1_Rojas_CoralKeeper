using UnityEngine;

public class ReefRestoreEffect : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelGoal levelGoal;
    [SerializeField] private SpriteRenderer caveBackRenderer;
    [SerializeField] private SpriteRenderer caveFrontRenderer;
    [SerializeField] private GameObject restoreBubbles;

    [Header("Restore")]
    [SerializeField] private Sprite healthyCaveBackSprite;
    [SerializeField] private Sprite healthyCaveFrontSprite;
    [SerializeField] private float healthyCoralDelay = 0.5f;

    private void Awake()
    {
        restoreBubbles.SetActive(false);
    }

    private void OnEnable()
    {
        levelGoal.OnReefRestored += HandleReefRestored;
    }

    private void OnDisable()
    {
        if(levelGoal  != null)
        {
        levelGoal.OnReefRestored -= HandleReefRestored;
        }
    }

    private void HandleReefRestored()
    {
        restoreBubbles.SetActive(true);
        Invoke(nameof(ShowHealthyCoral), healthyCoralDelay);
    }
    private void ShowHealthyCoral()
    {
        caveBackRenderer.sprite = healthyCaveBackSprite;
        caveFrontRenderer.sprite = healthyCaveFrontSprite;
    }
}
