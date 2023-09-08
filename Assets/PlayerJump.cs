using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{



    public Rigidbody2D rb;
    private float NextJump;
    public float jump_speed = 0.5f;
    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 10;
    public Input_master jump; 

    private void OnEnable(){
        jump.Enable();
    }
     private void OnDisable(){
        jump.Disable();
    }
    void Awake(){
        jump = new Input_master();
        jump.Player.Jump.performed += ctx => Jump();
    }
    void Jump(){
        
        NextJump = Time.time + jump_speed;
        rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        if(rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }
}



