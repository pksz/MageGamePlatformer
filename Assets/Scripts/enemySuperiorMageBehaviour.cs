using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySuperiorMageBehaviour : MonoBehaviour
{
    
    public Transform playerPosition;
    public Enemy enemy;
    public float aggroRange = 2f;
    public Transform spellOrigin;
    public GameObject spellPrefab;
    public float timeToAttack = 2f;
    float timeBtwShots = 0f;
    private Rigidbody2D rb2d;
    bool faceleft = true;
    public Animator animator;
    string currentState;
    const string attackanim = "fire_archonAttack";
    const string deathanim = "archonDeath";
    bool isliving;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentState = "fire_archonIdle";
        isliving = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (enemy.healthpoints == 0)
        {

            isliving = false;
            ChangeAnimationState(deathanim);
        }
        if (characterController2D.isalive  && isliving==true)
        {
            float distToPlayer = transform.position.x - playerPosition.position.x;
            float attckdistance = Vector2.Distance(transform.position, playerPosition.position);


            if (currentState == "fire_archonIdle"  && timeBtwShots<0.7)
            {
                ChangeAnimationState(attackanim);
            }
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
        Vector3 pos =new Vector3 (0, 1, 0);
        
        
        Instantiate(spellPrefab, spellOrigin.position, spellOrigin.rotation);
        Instantiate(spellPrefab, spellOrigin.position+pos, spellOrigin.rotation);
        Instantiate(spellPrefab, spellOrigin.position+(pos/2), spellOrigin.rotation);
        timeBtwShots = timeToAttack;
        ChangeAnimationState("fire_archonIdle");
    }


    //Animation control
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);
        Debug.Log(currentState);
        currentState = newState;
    }
    
}

