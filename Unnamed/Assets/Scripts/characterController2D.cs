using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterController2D : MonoBehaviour
{
    public healthbar healthbar;                                                        //reference to healthbar script
    public float moveSpeed = 5f;                                                 //movement speed of player
    public float jumpSpeed = 5f;                                                   // jumping force of player
    public Rigidbody2D rb;                                                             //rigidbody variable for player rigidbody
    float movement;                                                                   //stores horizontal movement state of player
    bool isright = true;
    public int healthMax = 100;
    int healthpoints;
    public static bool  isalive = true;
    public GameObject gameOverUI;
    // public GameObject deathanimation;
    // Start is called before the first frame update
    private void Start()
    {
        healthpoints = healthMax;
        healthbar.Maxhealth(healthMax);                                             //sets the hp at start 100%
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");           //get input on x axis
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.1f)                                                    //get jump input
        {
            jump();

        }

        healthbar.setHealth(healthpoints);                                                                      //sets the current hp(very intensive)
       
    }


    private void FixedUpdate()
    {
        transform.position += new Vector3(movement, 0, 0) * moveSpeed * Time.deltaTime;                            //move player position # does not apply force

        ///  flipping code
        ///  

        if(movement<0 && isright)
        {
            flip();
           }

        if(movement>0 && !isright)
        {
            flip();
        }


        void flip()
        {

            isright = !isright;
            transform.Rotate(0f, 180f, 0f);

        }


        ///check if player is alive

        if (isalive != true)
        {
            PlayerisDead();
        }

    }

 

    /// <summary>
    ///         JUMP FUNCTION
    /// </summary>
    void jump()
    {

        rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);

    }
    /// <summary>
    /// damge to  player
    /// </summary>
   public  void damage(int damage )
    {
        healthpoints -= damage;

        if (healthpoints <= 0)
        {
            healthpoints = 0;
            isalive = false;
        }
    }
   
    ///health gained
    ///
    public void health(int health)
    {   
        healthpoints += health;
        if (healthpoints > healthMax)                                                                                   //ehp never exceeds max possible hp
        {
            healthpoints = healthMax;
        }
    }

    //Implements code that runs when player dies

    private void PlayerisDead()
    {
        gameOverUI.SetActive(true);
        gameObject.SetActive(false);
        
    }




}
