using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterController2D : MonoBehaviour
{

    public healthbar healthbar;                                                     //reference to healthbar script
    public GameObject shield;                                                                //reference to shield gameObject;
    public float moveSpeed = 5f;                                                 //movement speed of player
    public float jumpSpeed = 5f;                                                   // jumping force of player
    public Rigidbody2D rb;                                                             //rigidbody variable for player rigidbody
    float movement;                                                                   //stores horizontal movement state of player
    bool isright = true;                                                                                    //facing right at start
    public int healthMax = 100;                                                                 //max health
     public int healthpoints;                                                                               //ehp
    public static bool isalive;                                
    public GameObject gameOverUI;                                                                       //triggers when game is over
    public float shieldDownTime = 10f;                                                                      //coolsown on shield
    float _shieldCoolDown;
    public int playerJumps=1;                                                                                                // no of player jumps
    int noOfJumps;                                                                                                              // no of player jumps
    bool isgrounded;                                                                                                                //player touches the ground
    public Transform groundcheck;
    public float checkradius;                                                                                                          //radius of the collider that dectects the ground 
    public LayerMask whatisground;                                                                                      //layers assigned will be recognised as ground
    
    // Start is called before the first frame update
    private void Start()
    {
        healthpoints = healthMax;
        healthbar.Maxhealth(healthMax);                                             //sets the hp at start 100%
        gameOverUI.SetActive(false);
        _shieldCoolDown = 0f;
        isalive = true;
        noOfJumps = playerJumps;

       
    }



    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");           //get input on x axis

        isgrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatisground);


        if (isgrounded)
        {
            noOfJumps = playerJumps;
        }



        if (Input.GetButtonDown("Jump") && noOfJumps > 0    )                                                    //get jump input
        {
           jump();

         }
        else if (Input.GetButtonDown("Jump") && noOfJumps == 0 && isgrounded == true)
        {
            jump();
        }
            ///////
            /// PLAYER SHIELD   
            //////
            if ( Input.GetKeyDown(KeyCode.E)  && _shieldCoolDown <= 0)
        {
            activateShield();
            _shieldCoolDown = shieldDownTime;
        }

        else if (_shieldCoolDown > 0)
        {                                                                                                                                      //cooldown time on shield
            _shieldCoolDown -= Time.deltaTime;
        }


        ////sets the current hp(very intensive)

        healthbar.setHealth(healthpoints);
        if (healthpoints > healthMax)
        {
            healthpoints = healthMax;
        }
        
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
        --noOfJumps;
        Debug.Log(noOfJumps);
        rb.velocity = Vector2.up * jumpSpeed;

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

    ///
    /// Activate shield function
    ///
    
     void activateShield()
    {
        
        shield.SetActive(true);
        
    }
   

}
