using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CoralProgressSo coralProgress;
    [SerializeField] private LevelGoal levelGoal;

    private void Start()
    {
        coralProgress.ResetProgress();
    }
}
