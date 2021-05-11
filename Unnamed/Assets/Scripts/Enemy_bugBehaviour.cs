using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bugBehaviour : MonoBehaviour
{
    public GameObject deatheffect;
    public characterController2D characterController2D;
    public Enemy enemy;
    public Transform playerPosition;
    public float attackrange = 2f;
    public float aggroRange = 5f;
    public  float chaseSpeed=3f;
    public int damageToPlayer=10;
    private Rigidbody2D rb2d;
    bool isalive;
    

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        isalive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isalive)
        {
            if (enemy.healthpoints <= 0)
            {
                Instantiate(deatheffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            float distToPlayer = Vector2.Distance(transform.position, playerPosition.position);

            // chase the player
            if ((distToPlayer <= aggroRange) && distToPlayer <= attackrange)
            {
                attack(damageToPlayer);
            }
            else if (distToPlayer <= aggroRange)
            {

                chasePlayer();

            }

            else
            {                                                                                                                           //stop chasing player



                stopChasingPlayer();

            }
        }
    }

    private void stopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
    }

    private void chasePlayer()
    {
   
            //enemy is to the left of the player(probably will never run)
        if (transform.position.x <= playerPosition.position.x)
        {
            rb2d.velocity = new Vector2(chaseSpeed, 0);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
           
        }
        //enemy is right of the player
        else if (transform.position.x > playerPosition.position.x)
        {
            rb2d.velocity = new Vector2(-chaseSpeed, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            
        }
    }

    private void attack(int damage)
    {
        rb2d.velocity = Vector2.zero;
        characterController2D.damage(damage);
        Instantiate(deatheffect, transform.position, transform.rotation);
        isalive = false;
        Destroy(gameObject);
        
    }

  
}
