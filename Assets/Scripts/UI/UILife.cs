using UnityEngine;

public class UILife : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject[] lifeIcons;

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += HandleHealthChanged;
    }
    private void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= HandleHealthChanged;
        }
    }

    private void HandleHealthChanged(int currentHealth)
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].SetActive(i < currentHealth);
        }
    }
}
