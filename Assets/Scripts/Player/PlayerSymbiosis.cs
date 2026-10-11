using UnityEngine;
using UnityEngine.Events;

public class PlayerSymbiosis : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    private float remainingTime;
    public bool IsActive => remainingTime > 0f;
    public float SpeedMultiplier => IsActive ? playerData.SymbiosisSpeedMultiplier : 1f;
    public float FireRateMultiplier => IsActive ? playerData.SymbiosisFireRateMultiplier : 1f;

    public event UnityAction<bool> OnSymbiosisChanged;      
    public event UnityAction<float> OnSymbiosisTimeChanged;

    public void Activate()
    {
        bool wasActive = IsActive;
        remainingTime = playerData.SymbiosisDuration;
        if (!wasActive)
        {
            OnSymbiosisChanged?.Invoke(true);
        }
        OnSymbiosisTimeChanged?.Invoke(remainingTime);

    }
    private void Update()
    {
        if (!IsActive) return;
        remainingTime -= Time.deltaTime;
        OnSymbiosisTimeChanged?.Invoke(Mathf.Max(remainingTime, 0f));
        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            OnSymbiosisChanged?.Invoke(false);
        }
        
    }
}
