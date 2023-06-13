using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpell : MonoBehaviour, StateActionInterface
    {
        [Header("参照元")]
        [SerializeField]
        private AnimationController animationController;
        [SerializeField]
        private GameObject DarkHand;
        [Header("数値")]
        [SerializeField]
        private float timer;

        GameObject Player = null;
        public void StateAction()
        {
            animationController.Spell();
            StartCoroutine(Spell());
        }

        public void StateEndAction()
        {
            StopCoroutine(Spell());
        }

        IEnumerator Spell()
        {
            yield return new WaitForSeconds(timer);
            if (getPlayer() != null)
            {
                SeManager.Instance.ShotSe(SeType.Spell);
                var hand = Instantiate(DarkHand, Player.transform.position, Quaternion.identity);
                hand.transform.parent = transform.parent;
                Destroy(hand, 3f);
            }
        }
        /// <summary>
        /// プレイヤーの情報を取得
        /// </summary>
        private GameObject getPlayer()
        {
            return Player = GameObject.FindWithTag("Player");
        }
    }
}