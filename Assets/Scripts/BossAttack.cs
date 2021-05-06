using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject attacksprite;
    
    // Start is called before the first frame update
 



    public void shootProjectile()
    {
        Instantiate(attacksprite, transform.position, transform.rotation);

    }

   
}
