using UnityEngine;
using UnityEngine.Events;
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
    private bool isPaused;
    public bool IsPaused => isPaused;
    public event UnityAction<bool> OnPauseChanged;


    private void Start()
    {
        coralProgress.ResetProgress();
        gameResult.ResetResult();

        Time.timeScale = 1.0f;
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

    public void SetPaused(bool paused)
    {
        if (paused == isPaused)
            return;
        isPaused = paused;
        Time.timeScale = isPaused ? 0f : 1f;
        OnPauseChanged?.Invoke(IsPaused);

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
