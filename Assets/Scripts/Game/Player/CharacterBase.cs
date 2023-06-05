using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour ,IDamageble
{
    [Header("‘Ì—Í")]
    [SerializeField]
    private float HP;
    public void AddDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            dead();
        }
    }

    public abstract void dead();
}
