using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float healthpoints = 100f;
   // public GameObject deathEffect;

public void takeDamage(int damage)
    {
        healthpoints -= damage;
  
        if (healthpoints <= 0)
        {
            die();
        }
    }


   public  void die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject,1f);
    }
}
