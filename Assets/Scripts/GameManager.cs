using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const float WinGameOverDelay = 3.5f;
    private const float LoseGameOverDelay = 1.5f;

    [SerializeField] private CoralProgressSo coralProgress;
    [SerializeField] private LevelGoal levelGoal;
    [SerializeField] private GameResultSo gameResult;
    [SerializeField] private PlayerHealth playerHealth;

    private bool gameEnded;


    private void Start()
    {
        coralProgress.ResetProgress();
        gameResult.ResetResult();
    }
    private void OnEnable()
    {
        levelGoal.OnReefRestored += HandleReefRestored;
        playerHealth.OnDied += HandlePlayerDied;
    }
    private void OnDisable()
    {
        if (levelGoal != null)
        {
            levelGoal.OnReefRestored -= HandleReefRestored;
        }
        if (playerHealth != null)
        {
            playerHealth.OnDied -= HandlePlayerDied;
        }
    }
    private void HandleReefRestored()
    {
        EndGame(true);
    }
    private void HandlePlayerDied()
    {
        EndGame(false);
    }
    private void EndGame(bool won)
    {
        if (gameEnded) 
            return; //guarda por si mi pez gana y en ese mismo momento muere

        gameEnded = true;
        gameResult.SetResult(won);
        Invoke(nameof(LoadGameOver), won ? WinGameOverDelay : LoseGameOverDelay);
    }
    private void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
