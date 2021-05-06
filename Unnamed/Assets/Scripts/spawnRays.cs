using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRays : MonoBehaviour
{
    
    
        public GameObject Raysprite;

        // Start is called before the first frame update




        public void shootRay()
        {
            Instantiate(Raysprite, transform.position, transform.rotation);

        }


    }


