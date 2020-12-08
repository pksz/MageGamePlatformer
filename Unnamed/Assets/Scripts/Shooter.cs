using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour

{
    public GameObject projectile;                               //stores projectile to be fired
    public float power;                                                 //speed of the projectile


    public AudioClip shootSFX;                                  //shooting sfx

 


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (projectile)
            {
                GameObject newprojectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;

                if (!newprojectile.GetComponent<Rigidbody2D>())
                {
                    newprojectile.AddComponent<Rigidbody2D>();
                }
                // Apply force to the newProjectile's Rigidbody component if it has one
                newprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

                if (shootSFX)
                {
                    if (newprojectile.GetComponent<AudioSource>())
                    { // the projectile has an AudioSource component
                      // play the sound clip through the AudioSource component on the gameobject.
                      // note: The audio will travel with the gameobject.
                        newprojectile.GetComponent<AudioSource>().PlayOneShot(shootSFX);
                    }
                    else
                    {
                        // dynamically create a new gameObject with an AudioSource
                        // this automatically destroys itself once the audio is done
                        AudioSource.PlayClipAtPoint(shootSFX, newprojectile.transform.position);
                    }


                }
            }

        }
    }
}
