using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackTwo : MonoBehaviour
{
    public GameObject attacksprite;
    
    // Start is called before the first frame update
 



    public void shootProjectile()
    {
        Instantiate(attacksprite, transform.position, transform.rotation);

    }

   
}
