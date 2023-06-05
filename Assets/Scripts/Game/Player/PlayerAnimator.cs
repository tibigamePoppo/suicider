using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("アニメーション")]
    [SerializeField]
    private Animator animator;

    public void Run(bool value)
    {
        animator.SetBool("Run", value);
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    public void Dead()
    {
        animator.SetTrigger("Death");
    }

    public void Fall(float value)
    {
        animator.SetFloat("AirSpeedY", value);
    }

    public void IsGround(bool value)
    {
        animator.SetBool("Grounded", value);
    }

}
