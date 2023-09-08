using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Input;

public class Player_Combat : MonoBehaviour
{
    public Animator animator;
    public Transform attack_point;
    public float attack_range = 20f;
    public LayerMask enemyLayer;

    public float attackspeed = 2f;

    private float NextFire;

    public int Damage=25;

    public Input_master attack; 

    private void OnEnable(){
        attack.Enable();
    }
     private void OnDisable(){
        attack.Disable();
    }
    void Awake(){
        attack = new Input_master();
        attack.Player.Attack.performed += ctx => Attack();
    }



    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0)&& Time.time>NextFire){
    //         NextFire = Time.time + attackspeed;
    //         Attack();

    //     }
        
    // }

    void Attack(){
        if (Time.time>NextFire){
            NextFire = Time.time + attackspeed;
            animator.SetTrigger("Attack");
            Collider2D[] enemy_hit = Physics2D.OverlapCircleAll(attack_point.position,attack_range,enemyLayer);
            foreach(Collider2D enemy in enemy_hit){
                Enemy en = enemy.gameObject.GetComponent<Enemy>();
                en.RecieveDamage(Damage);
            }
        }

    }
}
