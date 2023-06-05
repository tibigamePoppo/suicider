using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [Header("�_���[�W")]
    [SerializeField]
    private float damage;
    [Header("���邩�ǂ���")]
    [SerializeField]
    private bool isBreakable;
    [Header("�U���Ώۂ��v���C���[���ǂ���")]
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
