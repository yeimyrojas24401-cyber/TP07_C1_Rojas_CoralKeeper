using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Projectile projectilePrefab;

    private float shootTimer;

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        if (AnyKeyHeld(playerData.ShootKeys) && shootTimer <= 0)
        {
            Shoot();
            shootTimer = playerData.TimeBetweenShoots;
        }
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
        bubble.Init(new Vector2(dir, 0));
    }
}
