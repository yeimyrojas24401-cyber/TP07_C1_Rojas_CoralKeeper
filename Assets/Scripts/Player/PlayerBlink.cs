using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    [SerializeField]private PlayerHealth playerHealth;
    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]private PlayerDataSo playerData;

    private float blinkTimer;
    private void Update()
    {
        if (!playerHealth.IsInvulnerable)
        {
            spriteRenderer.enabled = true;
            return;
        }
        blinkTimer -= Time.deltaTime;
        if (blinkTimer <= 0)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            blinkTimer = playerData.BlinkInterval;
        }
    }
}
