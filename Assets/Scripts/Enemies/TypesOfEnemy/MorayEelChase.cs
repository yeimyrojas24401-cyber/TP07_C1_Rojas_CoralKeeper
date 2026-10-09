using UnityEngine;
using UnityEngine.UIElements;
public class MorayEelChase : MonoBehaviour
{
private enum MorayEelState
{
    Idle,
    Chase,
    Return
}
    [SerializeField] private EnemyDataSo morayEelData;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LayerMask playerLayer;

    private Vector2 homePosition;
    private Transform target;
    private MorayEelState currentState = MorayEelState.Idle;

    private const float ArriveThreshold = 0.1f;

    private void Start()
    {
        homePosition = rb.position;
    }
    private void FixedUpdate()
    {
        Collider2D hit = Physics2D.OverlapCircle(homePosition, morayEelData.DetectRange, playerLayer);

       if(hit != null)
        {
            currentState = MorayEelState.Chase;
            target = hit.transform;
        }
        else if (currentState == MorayEelState.Chase)        
        {
            currentState = MorayEelState.Return;
        }

        switch (currentState)
        {
            case MorayEelState.Idle:
                rb.linearVelocity = Vector2.zero;
                break;
            case MorayEelState.Chase:
                MoveTo(target.position, morayEelData.ChaseSpeed);
                break;
            case MorayEelState.Return:
                MoveTo(homePosition, morayEelData.ReturnSpeed);
                if (Vector2.Distance(rb.position, homePosition) < ArriveThreshold)  
                {
                    rb.linearVelocity = Vector2.zero;
                    currentState = MorayEelState.Idle;
                }
                break;
        }
    }
    private void MoveTo(Vector2 destination, float speed)
    {
        Vector2 direction = (destination - rb.position).normalized;
        rb.linearVelocity = direction * speed;
        spriteRenderer.flipX = direction.x < 0f;
    }
    //agregado para visualizar por ahora el tamano de mi circulo 
    private void OnDrawGizmosSelected()                      
    {
        if (morayEelData == null) return;
        Vector2 center = Application.isPlaying ? homePosition : (Vector2)transform.position;
        Gizmos.DrawWireSphere(center, morayEelData.DetectRange);
    }
}
