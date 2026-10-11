using UnityEngine;

public class SymbiosisPickup : Pickable
{
    protected override void ApplyEffect(GameObject player)
    {
        if(player.TryGetComponent(out PlayerSymbiosis playerSymbiosis))
        {
            playerSymbiosis.Activate();
        }
    }
}
