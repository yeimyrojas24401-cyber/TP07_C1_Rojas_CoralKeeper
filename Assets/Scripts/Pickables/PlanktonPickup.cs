using UnityEngine;

public class PlanktonPickup : Pickable
{
    [SerializeField] private int healAmount = 1;
    protected override void ApplyEffect(GameObject player)
    {
        if (player.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.AddLife(healAmount);
        }
    }
}
