using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        public void Attack()
        {
            animator.SetTrigger("Attack");
        }
        public void Spell()
        {
            animator.SetTrigger("Spell");
        }
        public void Hurt()
        {
            animator.SetTrigger("Hurt");
        }
        public void Walk(bool value)
        {
            animator.SetBool("Walk", value);
        }
    }
}