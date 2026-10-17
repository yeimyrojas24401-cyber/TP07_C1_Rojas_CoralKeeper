using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerSymbiosis playerSymbiosis;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Projectile projectilePrefab;

    [SerializeField] private PlayerAudio playerAudio;

    [SerializeField] private PlayerHealth playerHealth;

    private float shootTimer;
    private void OnEnable()
    {
        playerHealth.OnDied += HandleDied;
    }
    private void OnDisable()
    {
        if (playerHealth != null) playerHealth.OnDied -= HandleDied;
    }
    private void Update()
    {
        if (Time.timeScale == 0f) return; // en pausa no lee inputs
        shootTimer -= Time.deltaTime;
        if (AnyKeyHeld(playerData.ShootKeys) && shootTimer <= 0)
        {
            Shoot();
            shootTimer = playerData.TimeBetweenShoots / playerSymbiosis.FireRateMultiplier;
        }
    }

    private void HandleDied()
    {
        enabled = false;
    }

    private bool AnyKeyHeld(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
            if (Input.GetKey(key)) return true;
        return false;
    }

    private void Shoot()
    {
        float dir = playerMovement.FacingDirection;
        Vector2 spawnPosition = (Vector2) transform.position + new Vector2(playerData.ShootOffset.x * dir, playerData.ShootOffset.y);
        Projectile bubble = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        playerAudio.PlaySfx(playerData.ShootClip);

        bubble.Init(new Vector2(dir, 0)); // Le hace saber la direccion
    }
}
