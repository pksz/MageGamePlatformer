using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public BossAttack bossattack;
    public BossAttackTwo bossattackTwo;
    public BossAttackThree bossAttackThree;
    public spawnRays spawnRays;
    public int bossHealth = 100;
    public float timeBtwAttacks = 3f;
    public float baseDamage = 10f;
    public Slider slider;
    public float attackCooldownOne = 3f;
    bool weaponTwoUsed;
    int weaponUseCount;
    public Sprite bossPhaseTwoSprite;
    int bossStartingHealth;
    
    

    /// <summary>
    /// State machine to define boss phasesand behaviour
    /// weapon 2 is uesd every 3 counts of weapon 1
    /// 
    /// 
    /// </summary>
    public enum Statespace
    {
        intro,
        phase1,
        phase2,
        death
    }

    public Statespace state;


    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = bossHealth;
        slider.value = slider.maxValue;
        state = Statespace.intro;
        weaponTwoUsed = false;
        weaponUseCount = 0;
        bossStartingHealth = bossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttacks >0)
        {
            timeBtwAttacks -= Time.deltaTime;
        }

        if (weaponUseCount >= 3)
        {
            weaponTwoUsed = false;
        }

        




        switch (state)
        {
            case Statespace.intro:
                intro();
                if (Time.time > 3)
                {
                    state = Statespace.phase1;
                }
                    
                break;

            case Statespace.phase1:
                phase1();
                if (bossHealth <= bossStartingHealth/2)
                {
                    state = Statespace.phase2;
                }
                break;

            case Statespace.phase2:
                phase2();
                if (bossHealth < 1)
                {
                    state = Statespace.death;
                }

                break;
            case Statespace.death:
                break;




        }
            


    }


   // INTRO
    void intro()
    {


    }

//PHASE 1
    private void phase1()
    {
        if (timeBtwAttacks<0 && weaponTwoUsed==false)
        {
            weaponTwoUsed = true;
            timeBtwAttacks = attackCooldownOne;
            bossattackTwo.shootProjectile();
            weaponUseCount = 0;

        }

        else if(timeBtwAttacks < 0)
        {
            timeBtwAttacks = attackCooldownOne;
            bossattack.shootProjectile();
            weaponUseCount++;
        }
    }


  
  /// PHASE 2
    private void phase2()
    {
        Debug.Log("phase 2");
        //Play the transition animation



        // Changes the sprite of the boss
       SpriteRenderer currentSprite=gameObject.GetComponent<SpriteRenderer>();
        currentSprite.sprite = bossPhaseTwoSprite;
        BoxCollider2D boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        boxCollider2D.offset = new Vector2(0, 0);                                       //positions the hitbox correctly where sprite is

        
        //do the ray attacks
        if(timeBtwAttacks<0  && weaponTwoUsed ==true)
        {
            spawnRays.shootRay();
            timeBtwAttacks = attackCooldownOne;
            weaponUseCount++;
            weaponTwoUsed = false;
        }




        //shoot barrage 
      //  if (timeBtwAttacks < 0)
     //   {
      //      bossAttackThree.shootBarrage();
      //      timeBtwAttacks = attackCooldownOne;
      //      weaponUseCount++;
            //weaponTwoUsed = true;
            //

       // }

    }


    ////Damage and death


    public void takedamage(int damage)
    {
        bossHealth -= damage;
        slider.value = bossHealth;
        if (bossHealth <= 0)
            bossdied();



    }

    void bossdied()
    {

        Destroy(gameObject);
    }



}
