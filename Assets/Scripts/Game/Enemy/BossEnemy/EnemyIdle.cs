using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyIdle : MonoBehaviour, StateActionInterface
    {
        [Header("�Q�ƌ�")]
        [SerializeField]
        private EnemyBase stater;
        public void StateAction()
        {
            //StartCoroutine(RandomAction());
        }

        public void StateEndAction()
        {
            //StopCoroutine(RandomAction());
        }

        IEnumerator RandomAction()
        {
            yield return new WaitForSeconds(1f);
            stater.ChangeState(EnemyState.Walk);
        }
    }
}
