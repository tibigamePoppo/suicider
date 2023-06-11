using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour, StateActionInterface
    {
        [Header("éQè∆å≥")]
        [SerializeField]
        private AnimationController animationController;
        [SerializeField]
        private GameObject DamageColleder;
        [Header("êîíl")]
        [SerializeField]
        private float timer;
        public void StateAction()
        {
            animationController.Attack();
            DamageColleder.SetActive(true);
            StartCoroutine(CollederActiveFalseTimer());
        }

        public void StateEndAction()
        {
        }
        
        IEnumerator CollederActiveFalseTimer()
        {
            yield return new WaitForSeconds(timer);
            DamageColleder.SetActive(false);
        }

    }
}