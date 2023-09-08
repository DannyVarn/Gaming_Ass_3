using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_pot : MonoBehaviour
{
    // Start is called before the first frame update

    public Player player;

    public int health_res = 25;
    public GameObject p;
    
    public Rigidbody2D rb;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (player.HP<player.maxHP){
            player.Heal(health_res);
            Destroy(gameObject);
        }
    }
}
