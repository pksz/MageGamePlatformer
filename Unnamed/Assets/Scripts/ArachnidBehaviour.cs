using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArachnidBehaviour : MonoBehaviour
{
    public Enemy enemy;
    public Rigidbody2D arachinidrb;
    public int aggroRange=10;
    public int kiteDistance =5;
    public bool walkToPlayer = true;
    public float timeBetweenAttacks;
    public bool isFacingLeft =true;
    public Animator animator;
    public Transform player;
    public int damageToPlayer =6;
    public float moveSpeed = 8f;
    public Transform eye;                           //used as laser origin
    public LineRenderer laserShot;              //laser fx
    private float _attacktime;
    public SpriteRenderer eyeglow;
    public GameObject hiteffect;
    string currentState;
    const string idleState = "ArachnidIdle";
    const string deathState = "SpiderDeath";
    const string walkanim = "SpiderWalk";
    bool isalive;
    // Start is called before the first frame update

    void Start()
    {
        if (!isFacingLeft)
            transform.Rotate(0, 180, 0);

        if (arachinidrb == null)
        {
            arachinidrb = transform.GetComponent<Rigidbody2D>();
        }
        _attacktime = timeBetweenAttacks;
        eyeglow = eye.GetComponent<SpriteRenderer>();
      currentState = "ArachnidIdle";
        isalive = true;
    }

    // Update is called once per frame
    /// <summary>
    /// flipping and moving should be separate
    /// </summary>
    void Update()
    {//death
        if (!characterController2D.isalive)
            isalive = false;
        if (enemy.healthpoints <= 0)
        {
            ChangeAnimationState(deathState);
        }


        //flip the sprite
        float distToPlayer = player.position.x - transform.position.x;

        if (distToPlayer >= 0  && isFacingLeft) 

            flip();


        if (distToPlayer <= 0 && !isFacingLeft)
            flip();

      


       


    }

    private void FixedUpdate()
    {
        if (isalive)
        {
            // movement and distance to player
            float distToPlayer = player.position.x - transform.position.x;
            if (Mathf.Abs(distToPlayer) >= aggroRange)
            {
                arachinidrb.velocity = Vector2.down;
                ChangeAnimationState(idleState);
            }
            if (distToPlayer == kiteDistance)
            {
                arachinidrb.velocity = Vector2.down;
                ChangeAnimationState(idleState);
            }
            else if (distToPlayer < kiteDistance + (-2 * kiteDistance)  && Mathf.Abs(distToPlayer)<aggroRange)
            {
                arachinidrb.velocity = Vector2.left * moveSpeed;
                ChangeAnimationState(walkanim);
            }
            else if (distToPlayer >= kiteDistance && Mathf.Abs(distToPlayer)<aggroRange)
            {
                arachinidrb.velocity = Vector2.right * moveSpeed;
                ChangeAnimationState(walkanim);
            }

            //shoots the laser
            if (Mathf.Abs(distToPlayer) < kiteDistance && timeBetweenAttacks <= 0)
            {
                ChangeAnimationState(idleState);
                StartCoroutine(ShootLaser(damageToPlayer));
                timeBetweenAttacks = _attacktime;
            }

            //time reset
            if (timeBetweenAttacks > 0)
            {
                timeBetweenAttacks -= Time.deltaTime;
            }



        }
    }




    IEnumerator ShootLaser(int damage)
    {
        eyeglow.enabled = true;
        Vector3 playerPosition = transform.position - player.position;
        
        yield return new WaitForSeconds(0.25f);
        RaycastHit2D hitinfo = Physics2D.Raycast(eye.position,playerPosition.normalized*-100);
        eyeglow.enabled = false;
        Debug.DrawRay(eye.position, playerPosition.normalized*-100, Color.green);

       
        if (hitinfo)
        {
            laserShot.enabled = true;
            Debug.Log(hitinfo.collider.name);
            characterController2D characterController2D = hitinfo.transform.GetComponent<characterController2D>();
            Debug.Log(characterController2D);
            if (characterController2D != null  && hitinfo.transform.CompareTag("Player"))
            {
                Debug.Log(hitinfo);
                laserShot.SetPosition(0, eye.position);
                laserShot.SetPosition(1, hitinfo.point);
                characterController2D.damage(damage);
                Instantiate(hiteffect, player.position, player.rotation);
            }

            else if(hitinfo.transform.CompareTag("Environment"))
            {
                Debug.Log("hit something");

                laserShot.SetPosition(0, eye.position);
                laserShot.SetPosition(1, playerPosition.normalized*-100);

            }
        }

      

        yield return new WaitForSeconds(0.3f);

       laserShot.enabled = false;
    }


    void flip()
    {
        transform.Rotate(0, 180,0);
        isFacingLeft = !isFacingLeft;
    }


    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

       animator.Play(newState);
       Debug.Log(currentState);
        currentState = newState;
   }

}
