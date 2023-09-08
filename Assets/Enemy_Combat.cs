using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public Animator animator;
    public Transform attack_point;
    public float attack_range = 20f;
    public LayerMask enemyLayer;

    public float attackspeed = 2f;

    private float NextFire;

    public int Damage=25;

public float distance;
[SerializeField] public float discoverDistance;
[SerializeField] public float attackDistance;
[SerializeField] public int damage;
public Player player;

private float attackRate = 2f;


    void Update()
    {
        distance = Vector2.Distance(transform.position, player.gameObject.transform.position);

        if (distance <attackDistance && Time.time>NextFire)
        {
            Attack();
        }

        
    }

    void Attack(){
        animator.SetTrigger("Attack");
        player.RecieveDamage(damage);
        NextFire = Time.time + attackRate;
    }
}
