using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemies/EnemyData")]
public class EnemyDataSo : ScriptableObject
{
    [SerializeField] private int maxHealth = 4;
    public int MaxHealth => maxHealth;

    [SerializeField] private float moveSpeed = 1;
    public float MoveSpeed => moveSpeed;
    [SerializeField] private ParticleSystem deathVfx;
    public ParticleSystem DeathVfx => deathVfx;
}
