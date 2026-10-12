using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerDataSo playerData;
    private const float SwimThreshold = 0.1f;
    private int currentState;

    private bool isDead;
    private float damageTimer;
    private const float JumpThreshold = 0.5f;

    private void OnEnable()
    {
        playerHealth.OnDied += SelectDeathAnimation;
        playerHealth.OnTakeDamage += SelectDamageAnimation;
    }

    private void OnDisable()
    {
        playerHealth.OnDied -= SelectDeathAnimation;
        playerHealth.OnTakeDamage -= SelectDamageAnimation;
    }
    private void Update()
    {
        if (isDead) return;
        if(damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
            return;
        }
        if(rb.linearVelocity.y > JumpThreshold)
        {
            PlayAnimation(AnimatorStates.Jump);
        }
        else
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
    }
    private void SelectDeathAnimation()
    {
        isDead = true;
        PlayAnimation(AnimatorStates.Death);
    }

    private void SelectDamageAnimation()
    {
        damageTimer = playerData.DamageAnimationDuration;
        PlayAnimation(AnimatorStates.Damage);
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
