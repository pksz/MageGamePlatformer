using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrageSpell : MonoBehaviour
{
    public int damage = 5;
    public Rigidbody2D barrageSpells;
    public Transform Player;
    public float destroyTime = 3f;
    public float barrageVelocity = 15f;


    void Start()
    {
        if (characterController2D.isalive == true)
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;

            if (barrageSpells== null)
                transform.GetComponent<Rigidbody2D>();

            float xSpread = Random.Range(-2,2);
            float ySpread = Random.Range(-10, 10);

            transform.position = new Vector2(transform.position.x+xSpread, transform.position.y + ySpread);


        }

        else Destroy(gameObject);
    }


    void Update()
    {
        

        barrageSpells.AddForce(new Vector2(barrageVelocity,barrageVelocity)*-1);

        if (gameObject)
        {
            Destroy(gameObject, destroyTime);

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
            if (collision.CompareTag("Environment"))
                Destroy(gameObject);

        }
    }
}
