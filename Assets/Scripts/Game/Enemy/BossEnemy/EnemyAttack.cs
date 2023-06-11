using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour, StateActionInterface
    {
        [Header("�Q�ƌ�")]
        [SerializeField]
        private AnimationController animationController;
        [SerializeField]
        private GameObject DamageColleder;
        [Header("���l")]
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