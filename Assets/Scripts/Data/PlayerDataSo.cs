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

}
