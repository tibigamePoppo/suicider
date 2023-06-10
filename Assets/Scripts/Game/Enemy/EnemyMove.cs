using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour,StateActionInterface
{
    GameObject Player = null;
    [SerializeField]
    private float moveSpeed;
    public void StateActionInterface()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        if (Player == null) Player = getPlayer();
    }

    void Update()
    {
        if(Player == null) Player = getPlayer();
        Vector3 velocity = Vector3.zero;
        if(Player.transform.position.x > transform.position.x)
        {
            velocity.x++;
        }
        else
        {
            velocity.x--;
        }
        velocity = velocity * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(velocity.x, velocity.y, 0);
    }

    private GameObject getPlayer()
    {
        return Player = GameObject.FindWithTag("Player");
    }
}
