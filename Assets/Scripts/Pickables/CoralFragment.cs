using UnityEngine;

public class CoralFragment : Pickable
{
    [SerializeField] private CoralProgressSo coralProgress;
    protected override void ApplyEffect(GameObject player)
    {
        coralProgress.AddFragment();
    }
}
