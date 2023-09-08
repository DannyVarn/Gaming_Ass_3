using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
[SerializeField] public int HP;
[SerializeField] public int maxHP;
[SerializeField] public float speed = 3f;
public float distance;
[SerializeField] public GameObject p;
[SerializeField] public float discoverDistance;
[SerializeField] public float attackDistance;
public Hp_Bar healthbar;
[SerializeField] public int damage;
public Player player;
public Rigidbody2D rb;
private float NextFire;
private float attackRate = 2f;
private bool jump = false;
public float jumpAmount = 35;
public float gravityScale = 10;
public float fallingGravityScale = 10;
    public Animator animator;
    public Transform attack_point;

  public float movement =0f;
  float smooth = 5.0f;
  public float delay = 3;
float timer;

  void Start()
  {
    player = FindObjectOfType<Player>();
    HP = maxHP;
    healthbar = GetComponentInChildren<Hp_Bar>();
  }
  void Update()
  {
    distance = Vector2.Distance(transform.position, player.gameObject.transform.position);
    if (distance < discoverDistance)
    {
      
      transform.position = Vector2.MoveTowards(this.transform.position,new Vector2(player.gameObject.transform.position.x,rb.position.y),speed*Time.deltaTime);
    }
    animator.SetFloat("Movement",Mathf.Abs(distance));




    if (distance <attackDistance && Time.time>NextFire)
    {
      // player.RecieveDamage(damage);
      // NextFire = Time.time + attackRate;
      Attack();
    }
    if (jump)
        {
           rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        
        if(rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
        jump=false;
        }
  }
  void FixedUpdate(){
      if (player.gameObject.transform.position.x > 0 )
        {
                // Rotate the cube by converting the angles into a quaternion.
           
            float tiltAroundZ = 0;
            float tiltAroundX = 0;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        }
        if (player.gameObject.transform.position.x<0){
           
            float tiltAroundZ = 180;
            float tiltAroundX = 180;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);

        }
  }
  public void RecieveDamage(int dmg)
  {
    HP -= dmg;
    healthbar.UpdateHPBar((float)HP,(float)maxHP);
    if (HP <= 0)
    {
      die();
    }
  }

  void die(){
    animator.SetTrigger("Death");
    Invoke("Destroy_",0.5f);
    
  }
  void Destroy_(){
      Destroy(gameObject);
      
      SceneManager.LoadScene("victory_scene");
  }




  void Attack(){
        animator.SetTrigger("Attack");
        player.RecieveDamage(damage);
        NextFire = Time.time + attackRate;
    }



}
