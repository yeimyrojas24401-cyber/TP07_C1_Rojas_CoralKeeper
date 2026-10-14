using UnityEngine;

public class MorayEelAnimation : MonoBehaviour
{
    [SerializeField] private MorayEelChase morayEelChase;
    [SerializeField] private Animator animator;
    private int currentState;
    private void Update()
    {
        switch (morayEelChase.CurrentState)
        {
            case MorayEelChase.MorayEelState.Idle:
                PlayAnimation(AnimatorStates.Idle);
                break;
            case MorayEelChase.MorayEelState.Chase:
                PlayAnimation(AnimatorStates.Swim);
                break;
            case MorayEelChase.MorayEelState.Return:
                PlayAnimation(AnimatorStates.Swim);
                break;
        }
    }
    private void PlayAnimation(int state)
    {
        if (state == currentState) return;
        animator.Play(state);
        currentState = state;
    }
}
