using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSpell : MonoBehaviour
{
    public Transform Player;
    public float spellVelocity =3f;
    public int damage = 30;
    public Rigidbody2D spellBody;
    Vector3 playerDirection;
    public float destroyTime=3f;
    characterController2D Ref;
    // Start is called before the first frame update
    void Start()
    {
        if (characterController2D.isalive == true)
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;

            if (spellBody == null)
                transform.GetComponent<Rigidbody2D>();

            playerDirection = (transform.position - Player.position);



            
        }

        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        spellBody.velocity = playerDirection.normalized * spellVelocity*-1;
        
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
