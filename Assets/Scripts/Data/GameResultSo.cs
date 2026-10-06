using UnityEngine;
[CreateAssetMenu(fileName = "GameResultsData", menuName = "Data/Game/GameResulsData")]
public class GameResultSo : ScriptableObject
{
    [SerializeField] private bool won;
    public bool Won => won;

    private void SetResult(bool value)
    {
        won = false;
    }
    private void ResetResult()
    {
        won = false;
    }    
}
