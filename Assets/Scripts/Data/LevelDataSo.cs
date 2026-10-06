using UnityEngine;
[CreateAssetMenu(fileName = "LevelData", menuName = "Data/Game/LevelData")]
public class LevelDataSo : ScriptableObject
{
    [SerializeField] private int requiredFragments = 5;
    public int RequiredFragments => requiredFragments;
}
