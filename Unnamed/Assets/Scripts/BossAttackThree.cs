using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackThree : MonoBehaviour
{
    public GameObject attacksprite;
    public int projectilesToSpawn = 10;
    public float angleSpread = 45;
    
    // Start is called before the first frame update
 



    public void shootBarrage()
    {
        for ( int i= 0; i< projectilesToSpawn; i++)
        {

           // float xSpread = Random.Range(-30, 30);
        //    float ySpread = Random.Range(-1, 1);
            //var bullet = (GameObject)Instantiate(attacksprite, transform.position, Quaternion.Euler(xSpread,ySpread,0));            ///???????????????????


            // bullet.transform.Rotate(xSpread, ySpread, 0);

            Instantiate(attacksprite,transform.position, transform.rotation);
            transform.Rotate(0, 0, 5);
            

        }

    }

   
}
