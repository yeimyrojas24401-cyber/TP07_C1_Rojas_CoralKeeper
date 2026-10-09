using UnityEngine;
public class MorayEelChase : MonoBehaviour
{
private enum MorayEelState
{
    Idle,
    Chase,
    Return
}
    [SerializeField] private EnemyDataSo MoralEelData;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform homePosition;
    
    private MorayEelState currentState = MorayEelState.Idle;
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = homePosition.position;
    }
    private void Update()
    {
        switch (currentState)
        {
            case MorayEelState.Idle:
                break;
            case MorayEelState.Chase:
                break;
            case MorayEelState.Return:
                break;
        }
    }
}
