using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{ 
    public float shieldActiveDuration = 5f;
    float shieldUptime;
    // Start is called before the first frame update
    private void Start()
    {
        shieldUptime = shieldActiveDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldUptime <= 0) { 
              shieldUptime = shieldActiveDuration;
              deactivateShield();
    }
            else
            {
                shieldUptime -= Time.deltaTime;
            }
        
        }
        

    private void deactivateShield()                                                                                                                             //deactivate function
    {
        
        gameObject.SetActive(false);
    }

   
}

