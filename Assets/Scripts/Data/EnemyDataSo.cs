using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemies/EnemyData")]
public class EnemyDataSo : ScriptableObject
{
    [Header("General Settings")]
    [SerializeField] private int maxHealth = 4;
    public int MaxHealth => maxHealth;
    [SerializeField] private ParticleSystem deathVfx;
    public ParticleSystem DeathVfx => deathVfx;

    [Header("Starfish patrol general Settings")]
    [SerializeField] private float moveSpeed = 1;
    public float MoveSpeed => moveSpeed;

    [Header("Moray eel chase general settings")]
    [SerializeField] private float detectRange = 5;
    public float DetectRange => detectRange;

    [SerializeField] private float chaseSpeed = 3.5f;
    public float ChaseSpeed => chaseSpeed;
    [SerializeField] private float returnSpeed = 2.0f;
    public float ReturnSpeed => returnSpeed;

}
