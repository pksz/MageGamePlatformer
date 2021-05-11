using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyDamageToPlayer : MonoBehaviour
{
    int damage = 1;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        characterController2D cc2d = collision.GetComponent<characterController2D>();
        
         if (cc2d != null && collision.CompareTag("Player"))
        {

            cc2d.damage(damage);
            Destroy(gameObject, 5);
        }
        else
        {
            
                Destroy(gameObject,5);

        }
    }
}
