using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CoralProgressSo coralProgress;

    private void Start()
    {
        coralProgress.ResetProgress();
    }
}
