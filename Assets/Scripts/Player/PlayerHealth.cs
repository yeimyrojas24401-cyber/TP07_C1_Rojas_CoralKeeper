using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    private int currentHealth;
    public int CurrentHealth => currentHealth;
    private float invulnerabilityTimer;
    public bool IsInvulnerable => invulnerabilityTimer > 0; //responde a la necesidad de que no todo baje de un solo bajon
    private bool isDead;

    public event UnityAction<int> OnHealthChanged;
    public event UnityAction OnDied;

    private void Start()
    {
        currentHealth = playerData.MaxHealth;
        OnHealthChanged?.Invoke(CurrentHealth);
    }
    private void Update()
    {
        if (invulnerabilityTimer > 0)
        {
            invulnerabilityTimer -= Time.deltaTime;
        }

    }
    public void TakeHit()
    {
        if (isDead || IsInvulnerable) return;
        currentHealth--;
        OnHealthChanged?.Invoke(CurrentHealth);
        Debug.Log($"Vida: {currentHealth}");
        if (currentHealth <= 0)
        {
            isDead = true;
            OnDied?.Invoke();
            Debug.Log("El pez murio");
            return;
        }
        invulnerabilityTimer = playerData.InvulnerabilityDuration;
    }
    public void AddLife(int amount) //pickable para anemona
    {
        if (isDead) return;
        currentHealth = Mathf.Min(currentHealth + amount, playerData.MaxHealth);
        OnHealthChanged?.Invoke(CurrentHealth);
    }
    private void HandleContact(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyMarker>(out _))
        {
            TakeHit();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleContact(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        HandleContact(collision);
    }
}
