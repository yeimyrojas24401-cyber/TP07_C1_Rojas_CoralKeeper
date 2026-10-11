using System;
using UnityEngine;

public class PlayerSymbiosisTint : MonoBehaviour
{
    [SerializeField] private PlayerSymbiosis playerSymbiosis;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerDataSo playerData;

    private void OnEnable()
    {
        playerSymbiosis.OnSymbiosisChanged += HandleSymbiosisChanged;
    }
    private void OnDisable()
    {
        if (playerSymbiosis != null)
        playerSymbiosis.OnSymbiosisChanged -= HandleSymbiosisChanged;

    }

    private void HandleSymbiosisChanged(bool isActive)
    {
        spriteRenderer.color = isActive ? playerData.SymbiosisColor : Color.white;
    }
}
