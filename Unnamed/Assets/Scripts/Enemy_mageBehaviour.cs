﻿
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_mageBehaviour : MonoBehaviour
{   
    public Enemy enemy;
    public GameObject deatheffect;
    public Animator animator;
    public Transform playerPosition;
    public float aggroRange = 2f;
    public Transform spellOrigin;
    public GameObject spellPrefab;
    public float timeToAttack = 2f;
    float timeBtwShots = 0f;
    private Rigidbody2D rb2d;
    bool faceleft = true;
    bool isliving;
 
    
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        isliving = true;                                                                                                                       
    }

    // Update is called once per frame
    void Update()
    {
      if (enemy.healthpoints <= 0)
        {
            Instantiate(deatheffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


        if (characterController2D.isalive && isliving==true)
        {
            float distToPlayer = transform.position.x - playerPosition.position.x;
            float attckdistance = Vector2.Distance(transform.position, playerPosition.position);


            // look at the player
            if (distToPlayer <= 0f && faceleft)
            {
                flipMage();
            }
            if (distToPlayer >= 0f && !faceleft)
            {
                flipMage();
            }
            ///reducing time b/wshots

            if (timeBtwShots > 0)
            {
                timeBtwShots -= Time.deltaTime;
            }
            ///

            //attack range
            if (attckdistance < aggroRange && timeBtwShots <= 0)
            {
               
                attackPlayer();

            }
            
        }
    }

 /// <summary>
 /// flips the mage
 /// </summary>
    private void flipMage()
    {
        transform.Rotate(0f, 180f, 0f);
        faceleft = !faceleft;
    }


/// <summary>
/// attacks the player if in aggro range
/// </summary>
    
   private void attackPlayer()
    {
        
        Instantiate (spellPrefab, spellOrigin.position, spellOrigin.rotation);
        timeBtwShots = timeToAttack;
    }



   

}
