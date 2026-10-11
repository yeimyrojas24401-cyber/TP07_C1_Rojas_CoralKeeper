using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CoralProgressSo coralProgress;
    [SerializeField] private LevelGoal levelGoal;
    [SerializeField] private GameResultSo gameResult;
    [SerializeField] private TMP_Text winText;
    [SerializeField] private PlayerHealth playerHealth;

    private bool gameEnded;


    private void Start()
    {
        coralProgress.ResetProgress();
        gameResult.ResetResult();
        winText.text = "";
    }
    private void OnEnable()
    {
        levelGoal.OnReefRestored += HandleReefRestored;
        playerHealth.OnDied += HandlePlayerDied;
    }
    private void OnDisable()
    {
        if (levelGoal != null)
        levelGoal.OnReefRestored -= HandleReefRestored;
        if(playerHealth != null)
        {
            playerHealth.OnDied -= HandlePlayerDied;
        }
    }
    private void HandleReefRestored()
    {
        winText.text = "Arrecife Restaurado!";
        EndGame(true);
    }
    private void HandlePlayerDied()
    {
        EndGame(false);
    }
    private void EndGame(bool won)
    {
        if (gameEnded) return;
        gameEnded = true;
        gameResult.SetResult(won);
        Invoke(nameof(LoadGameOver), 1.5f);
    }
    private void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
