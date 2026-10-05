using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float moveInput;
    bool swimRequested;
    float swimTimer;

    private void Update()
    {
        moveInput = 0f;
        if (AnyKeyHeld(data.RightKeys))
        {
            moveInput += 1f;
        }
        if (AnyKeyHeld(data.LeftKeys))
        {
            moveInput -= 1f;
        }
        
        if (swimTimer > 0f)
        {
            swimTimer -= Time.deltaTime;
        }
        if (AnyKeyDown(data.SwimUpKeys) && swimTimer <= 0f)
        {
            swimRequested = true;
            swimTimer = data.TimeBetweenSwims;
        }
        if (moveInput != 0f)
            spriteRenderer.flipX = moveInput < 0f;
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * data.MoveSpeed, rb.linearVelocity.y);

        if (swimRequested)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * data.SwimUpForce, ForceMode2D.Impulse);
            swimRequested = false;
        }
    }
    private bool AnyKeyHeld(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
            if (Input.GetKey(key)) return true;
        return false;
    }
    private bool AnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
            if (Input.GetKeyDown(key)) return true;
        return false;
    }
}
