using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mageball : MonoBehaviour
{
    public float ballVelocity = 10f;
    public Rigidbody2D rb;
    public int damage = 40;
    public Transform Player;
  
    void Start()
    {
        if (rb == null) transform.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    private void Update()
    {   
        transform.position = Vector2.MoveTowards(transform.position, Player.position,ballVelocity*Time.deltaTime);

        if (gameObject)
        {
            Destroy(gameObject, 5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        characterController2D cc2d = collision.GetComponent<characterController2D>();
        if (cc2d != null && collision.CompareTag("Player"))
        {
            
            cc2d.damage(damage);
            Destroy(gameObject);
        }
        else
        {   
            if(collision.CompareTag("Environment"))
            Destroy(gameObject );

        }
    }
    
}

   


