using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayWalk()
    {
        animator.SetTrigger("Walk");
    }

    public void PlayAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void PlayHit()
    {
        animator.SetTrigger("Hit");
    }

    public void PlayDie()
    {
        animator.SetTrigger("Die");
    }
}
