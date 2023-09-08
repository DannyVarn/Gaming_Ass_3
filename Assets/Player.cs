using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

  [SerializeField] public int HP=300;
  [SerializeField] public int maxHP=300;
  public Hp_Bar healthbar;

  public Animator animator;


  void Start()
  {
    HP = maxHP;
    healthbar = GetComponentInChildren<Hp_Bar>();
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

  void die()
  {
    animator.SetTrigger("Death");
    Invoke("Destroy_",0.8f);
    
    
  }
    void Destroy_(){
      Destroy(gameObject);
      SceneManager.LoadScene("lose_scene");
  }
  public void Heal(int heal){
    if (heal+HP>maxHP){
      HP =maxHP;
    }
    else
      HP += heal;
    healthbar.UpdateHPBar((float)HP,(float)maxHP);
  }


}
