using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CoralProgressSo coralProgress;
    [SerializeField] private LevelGoal levelGoal;
    [SerializeField] private GameResultSo gameResult;
    [SerializeField] private TMP_Text winText;

    private void Start()
    {
        coralProgress.ResetProgress();
        gameResult.ResetResult();
        winText.text = "";
    }
    private void OnEnable()
    {
        levelGoal.OnReefRestored += HandleReefRestored;
    }
    private void OnDisable()
    {
        if (levelGoal != null)
        levelGoal.OnReefRestored -= HandleReefRestored;
    }
    private void HandleReefRestored()
    {
        gameResult.SetResult(true);
        winText.text = "Arrecife Restaurado!";
    }
}
