using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [Header("ダメージ")]
    [SerializeField]
    private float damage;
    [Header("壊れるかどうか")]
    [SerializeField]
    private bool isBreakable;
    [Header("攻撃対象がプレイヤーかどうか")]
    [SerializeField]
    private bool targetPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(targetPlayer)
        {
            if(!collision.CompareTag("Player"))
            {
                return;
            }
        }
        else
        {
            if(collision.CompareTag("Player"))
            {
                return;
            }
        }
        if(collision.TryGetComponent(out IDamageble damagable))
        {
            damagable.AddDamage(damage);
            if (isBreakable)
            {
                Destroy(gameObject);
            }
        }
    }
}
