using UnityEngine;
using TMPro;
using System;

public class UISymbiosisTimer : MonoBehaviour
{
    [SerializeField] private PlayerSymbiosis playerSymbiosis;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text timerText;

    private void Start()
    {
        panel.SetActive(false);
    }
    private void OnEnable()
    {
        playerSymbiosis.OnSymbiosisChanged += HandleSymbiosisChanged;
        playerSymbiosis.OnSymbiosisTimeChanged += HandleTimeChanged;
    }
    private void OnDisable()
    {
        if (playerSymbiosis == null) return;
        playerSymbiosis.OnSymbiosisChanged -= HandleSymbiosisChanged;
        playerSymbiosis.OnSymbiosisTimeChanged -= HandleTimeChanged;
    }
    private void HandleSymbiosisChanged(bool isActive)
    {
        panel.SetActive(isActive);
    }

    private void HandleTimeChanged(float time)
    {
        timerText.text = $"Simbiosis {Mathf.CeilToInt(time)}";
    }

}
