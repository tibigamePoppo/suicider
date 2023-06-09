using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour, StateActionInterface
    {
        [Header("参照元")]
        [SerializeField]
        private AnimationController animationController;
        [SerializeField]
        private GameObject DamageColleder;
        [Header("数値")]
        [SerializeField]
        private float startTimer;
        [SerializeField]
        private float endTimer;
        public void StateAction()
        {
            animationController.Attack();
            StartCoroutine(CollederActiveFalseTimer());
        }

        public void StateEndAction()
        {
        }
        
        IEnumerator CollederActiveFalseTimer()
        {
            yield return new WaitForSeconds(startTimer);
            SeManager.Instance.ShotSe(SeType.EnemyAttack);
            DamageColleder.SetActive(true);
            yield return new WaitForSeconds(endTimer);
            DamageColleder.SetActive(false);
        }

    }
}