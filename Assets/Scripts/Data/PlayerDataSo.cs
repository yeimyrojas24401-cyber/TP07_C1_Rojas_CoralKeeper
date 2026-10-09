using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Game/PlayerData")]
public class PlayerDataSo : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] private KeyCode[] rightKeys = { KeyCode.D, KeyCode.RightArrow };
    public KeyCode[] RightKeys => rightKeys;

    [SerializeField] private KeyCode[] leftKeys = { KeyCode.A, KeyCode.LeftArrow };
    public KeyCode[] LeftKeys => leftKeys;

    [SerializeField] private KeyCode[] swimUpKeys = { KeyCode.Space, KeyCode.W, KeyCode.UpArrow };
    public KeyCode[] SwimUpKeys => swimUpKeys;

    [Header("Speed")]
    [SerializeField] private float moveSpeed = 5f;
    public float MoveSpeed => moveSpeed;

    [Header("Swimming")]
    [SerializeField] private float swimUpForce = 10f;
    public float SwimUpForce => swimUpForce;

    [SerializeField] private float timeBetweenSwims = 0.35f;
    public float TimeBetweenSwims => timeBetweenSwims;

    [SerializeField] private KeyCode[] diveKeys = { KeyCode.S, KeyCode.DownArrow };
    public KeyCode[] DiveKeys => diveKeys;

    [SerializeField] private float diveSpeed = 4f;
    public float DiveSpeed => diveSpeed;

    [Header("Health")]
    [SerializeField] private int maxHealth = 5;
    public int MaxHealth => maxHealth;
    [SerializeField] private float invulnerabilityDuration = 1.5f;
    public float InvulnerabilityDuration => invulnerabilityDuration;

    [SerializeField] private float blinkInterval = 0.1f;
    public float BlinkInterval => blinkInterval;

    [Header("Shooting")]
    [SerializeField] private KeyCode[] shootKeys = { KeyCode.J, KeyCode.Mouse0 };
    public KeyCode[] ShootKeys => shootKeys;
    [SerializeField] private float timeBetweenShoots = 0.3f;
    public float TimeBetweenShoots => timeBetweenShoots;
    [SerializeField] private Vector2 shootOffset = new Vector2(0.6f, 0f);
    public Vector2 ShootOffset => shootOffset;
}
