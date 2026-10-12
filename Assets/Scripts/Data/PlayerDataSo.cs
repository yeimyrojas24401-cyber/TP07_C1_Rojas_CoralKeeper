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

    [SerializeField] private float damageAnimationDuration = 0.4f;
    public float DamageAnimationDuration => damageAnimationDuration;

    [Header("Shooting")]
    [SerializeField] private KeyCode[] shootKeys = { KeyCode.J, KeyCode.Mouse0 };
    public KeyCode[] ShootKeys => shootKeys;
    [SerializeField] private float timeBetweenShoots = 0.3f;
    public float TimeBetweenShoots => timeBetweenShoots;
    [SerializeField] private Vector2 shootOffset = new Vector2(0.6f, 0f);
    public Vector2 ShootOffset => shootOffset;

    [Header("Symbiosis")]
    [SerializeField] private float symbiosisDuration = 8f;
    public float SymbiosisDuration => symbiosisDuration;
    [SerializeField] private float symbiosisSpeedMultiplier = 1.5f;
    public float SymbiosisSpeedMultiplier => symbiosisSpeedMultiplier;
    [SerializeField] private float symbiosisFireRateMultiplier = 2f;

    public float SymbiosisFireRateMultiplier => symbiosisFireRateMultiplier;

    [SerializeField] private Color symbiosisColor = new Color(1f, 0.6f, 0.9f);
    public Color SymbiosisColor => symbiosisColor;

    [Header("Audio")]
    [SerializeField] private AudioClip swimClip;
    public AudioClip SwimClip => swimClip;
    [SerializeField] private AudioClip shootClip;
    public AudioClip ShootClip => shootClip;
    [SerializeField] private AudioClip hurtClip;
    public AudioClip HurtClip => hurtClip;

}
