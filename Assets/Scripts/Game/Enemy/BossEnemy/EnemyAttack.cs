using Audio;
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