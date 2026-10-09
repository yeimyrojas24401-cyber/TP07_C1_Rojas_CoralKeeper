using UnityEngine;

public class StarfishPatrol : MonoBehaviour
{
    [SerializeField] private EnemyDataSo starfishData;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    private Vector2 positionA;
    private Vector2 positionB;
    private Vector2 currentTarget;

    private const float ArriveThreshold = 0.1f;

    private bool isGoingToB;

    private void Start()
    {
        positionA = (pointA.position);
        positionB = (pointB.position);

        currentTarget = positionB;
        spriteRenderer.flipX = (currentTarget.x < rb.position.x);

        isGoingToB = true;

    }
    private void FixedUpdate()
    {
        Vector2 next = Vector2.MoveTowards(rb.position, currentTarget, starfishData.MoveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(next);

        if (Vector2.Distance(rb.position, currentTarget) < ArriveThreshold)
        {
            isGoingToB = !isGoingToB;
            if (isGoingToB)
            {
                currentTarget = positionB;
            }
            else
            {
                currentTarget = positionA;
            }
            spriteRenderer.flipX = (currentTarget.x < rb.position.x);
        }
    }
}
