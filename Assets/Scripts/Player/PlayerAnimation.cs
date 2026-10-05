using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private const float SwimThreshold = 0.1f;
    private int currentState;

    private void Update()
    {
        float currentVelocity;
        currentVelocity = Mathf.Abs(rb.linearVelocity.x);

        if (currentVelocity >  SwimThreshold)
        {
            PlayAnimation(AnimatorStates.Swim);
        }
        else
        {
            PlayAnimation(AnimatorStates.Idle);
        }

    }
    private void PlayAnimation(int state)
    {
        if (state == currentState)
        {
            return;
        }
        animator.Play(state);
        currentState = state;
    }
}
