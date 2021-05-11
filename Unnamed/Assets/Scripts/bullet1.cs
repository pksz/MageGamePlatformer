using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1 : MonoBehaviour
{
    public float bulletVelocity=20f;
    public Rigidbody2D rb;
    public int damage = 20;
    public SpriteRenderer SpriteRenderer;
    void Start()
    {
        Vector3 relativeMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rb.velocity = relativeMousePosition.normalized * bulletVelocity;
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Boss boss = collision.GetComponent<Boss>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
            Destroy(gameObject);

        }
        else if(boss != null)
        {
            boss.takedamage(damage);
            Destroy(gameObject);
        }
        else
            Destroy(gameObject, 5f);
        
        

       
    }
    
}
