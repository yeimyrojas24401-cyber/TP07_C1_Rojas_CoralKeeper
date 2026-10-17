using UnityEngine;

public class LionfishShooter : MonoBehaviour
{
    [SerializeField] private EnemyDataSo lionfishData;
    [SerializeField] private Projectile spinePrefab;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform firePoint;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private GameManager gameManager;
    private float shootTimer;

    private void Update()
    {
        if (gameManager.IsPaused)
            return;
        shootTimer -= Time.deltaTime;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, lionfishData.DetectRange, playerLayer);
        if (hit == null) return;
        if (shootTimer > 0) return;
        Shoot(hit.transform.position);
        shootTimer = lionfishData.TimeBetweenShoots;
    }
    private void Shoot(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - (Vector2)(firePoint.position)).normalized;
        spriteRenderer.flipX = direction.x < 0f;
        Projectile spine = Instantiate(spinePrefab, firePoint.position, Quaternion.identity);
        animator.Play(AnimatorStates.Attack, 0, 0f);
        spine.Init(direction);
    }
    private void OnDrawGizmosSelected()
    {
        if (lionfishData == null) return;
        Gizmos.DrawWireSphere(transform.position, lionfishData.DetectRange);
    }
}
