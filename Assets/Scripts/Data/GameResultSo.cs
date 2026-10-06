using UnityEngine;
[CreateAssetMenu(fileName = "GameResultData", menuName = "Data/Game/GameResultData")]
public class GameResultSo : ScriptableObject
{
    [SerializeField] private bool won;
    public bool Won => won;

    public void SetResult(bool value)
    {
        won = value;
    }
    public void ResetResult()
    {
        won = false;
    }    
}
