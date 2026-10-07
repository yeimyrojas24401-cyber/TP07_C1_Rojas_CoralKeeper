using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyDataSo enemyData;
    private int currentHealth;
    private bool isDead;
    public int MaxHealth => enemyData.MaxHealth;
    public event UnityAction<int> OnHealthChanged;

    private void Start()
    {
        currentHealth = MaxHealth;
        OnHealthChanged?.Invoke(currentHealth);
    }
    public void TakeDamage(int amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        OnHealthChanged?.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Instantiate(enemyData.DeathVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
