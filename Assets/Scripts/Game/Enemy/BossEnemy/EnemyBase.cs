using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        [Header("éQè∆å≥")]
        [SerializeField]
        private EnemyMove Move;
        [SerializeField]
        private EnemyIdle Idle;
        [SerializeField]
        private EnemyAttack Attack;
        [SerializeField]
        private EnemySpell Spell;
        private EnemyState state;

        public void ChangeState(EnemyState s)
        {
            switch (state)
            {
                case EnemyState.Idle:
                    Idle.StateEndAction();
                    break;
                case EnemyState.Walk:
                    Move.StateEndAction();
                    break;
                case EnemyState.Attack:
                    Attack.StateEndAction();
                    break;
                case EnemyState.Action1:
                    Spell.StateEndAction();
                    break;
                default:
                    break;
            }
            state = s;
            switch (state)
            {
                case EnemyState.Idle:
                    Idle.StateAction();
                    break;
                case EnemyState.Walk:
                    Move.StateAction();
                    break;
                case EnemyState.Attack:
                    Attack.StateAction();
                    break;
                case EnemyState.Action1:
                    Spell.StateAction();
                    break;
                default:
                    break;
            }
        }

        private void Start()
        {
            ChangeState(EnemyState.Idle);
        }
    }
}