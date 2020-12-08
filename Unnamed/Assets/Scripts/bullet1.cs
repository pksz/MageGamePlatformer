using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1 : MonoBehaviour
{
    public float bulletVelocity=20f;
    public Rigidbody2D rb;
    public int damage = 20;
    void Start()
    {
        rb.velocity = transform.right * bulletVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
            Destroy(gameObject);

        }
        else
            Destroy(gameObject, 5f);
        
        

       
    }
    
}
