using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRays : MonoBehaviour
{
    
    
        public GameObject[] Raysprite;
         public Transform referencePoint;
        public GameObject[] Raysprite2;
        public float offset;
        // Start is called before the first frame update




        public void shootRay()
        {

            StartCoroutine(shootRays());
        }
    IEnumerator shootRays()
    {
       for (int i = 0; i < Raysprite.Length; i++)

        {
            Instantiate(Raysprite[i], transform.position + new Vector3(offset * i, 0, 0), transform.rotation);


            yield return new WaitForSeconds(0.3f);
        }
       
        yield return new WaitForSeconds(1.5f);


        for(int i = 0; i < Raysprite2.Length; i++)
        {
            Instantiate(Raysprite2[i], referencePoint.transform.position + new Vector3(offset * i, 0, 0), referencePoint.transform.rotation);


            yield return new WaitForSeconds(0.3f);


        }




    }



    }


