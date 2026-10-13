using UnityEngine;

public static class AnimatorStates
{
    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Swim = Animator.StringToHash("Swim");
    public static readonly int Jump = Animator.StringToHash("Jump");
    public static readonly int Damage = Animator.StringToHash("Damage");
    public static readonly int Death = Animator.StringToHash("Death");
    public static readonly int Attack = Animator.StringToHash("Attack");
}
