using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bugBehaviour : MonoBehaviour
{
    public characterController2D characterController2D;
    public Enemy enemy;
    public Transform playerPosition;
    public float attackrange = 2f;
    public float aggroRange = 5f;
    public  float chaseSpeed=3f;
    public int damageToPlayer=10;
    private Rigidbody2D rb2d;
    private Vector3 startingPosition;
    private Vector3 randomDirection;
    //public Animation bugExplode;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        startingPosition = transform.position;                                                                                                 //stores the initial position of the enemy
        randomDirection = new Vector3(UnityEngine.Random.Range(1f, -1f),1).normalized;                  //random movement threshhold
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, playerPosition.position);

        // chase the player
        if ((distToPlayer < aggroRange)&& distToPlayer<attackrange)
        {
            attack(damageToPlayer);
        }
        else if (distToPlayer < aggroRange)
        {

            chasePlayer();

        }
      
      else  {                                                                                                                           //stop chasing player
                                                                                
      

            stopChasingPlayer();

        }
        
    }

    private void stopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
    }

    private void chasePlayer()
    {
        if (transform.position.x < playerPosition.position.x)
        {
            attack(damageToPlayer);
        }
            //enemy is to the left of the player(probably will never run)
        else if (transform.position.x < playerPosition.position.x)
        {
            rb2d.velocity = new Vector2(chaseSpeed, 0);
            transform.localScale = new Vector2(-.2f, .2f);
        }
        //enemy is right of the player
        else 
        {
            rb2d.velocity = new Vector2(-chaseSpeed, 0);
            transform.localScale = new Vector2(.2f, .2f);
        }
    }

    private void attack(int damage)
    {
        rb2d.velocity = Vector2.zero;
        characterController2D.damage(damage);
        
        enemy.die();
        //bugExplode.Play();
    }

  
}
