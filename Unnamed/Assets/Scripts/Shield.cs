using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float shieldCooldown = 10f;
    float _shildcooldown = 0f;
    public float shieldActiveDuration = 5f;
    bool isShieldActive;
    float _shieldActiveDuration;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        isShieldActive = false;
        _shieldActiveDuration = shieldActiveDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _shildcooldown<=0f)                                                                               //activate shield
        {
            Debug.Log("fbufeu");
            activateShield();

        }

        if (_shildcooldown > 0)                                                                                                                                         //cooldown time on shield
            _shildcooldown -= Time.deltaTime;

        if (isShieldActive)                                                                                                                                                     //deaactivate shield
        {
            if (_shieldActiveDuration <= 0)
                deactivateShield();
            else
            {
                _shieldActiveDuration -= Time.deltaTime;
            }

        }
        }

    private void deactivateShield()                                                                                                                             //deactivate function
    {
        gameObject.SetActive(false);
        _shieldActiveDuration = shieldActiveDuration;
        isShieldActive = false;
    }

    private void activateShield()                                                                                                                               ////  activate function
    {
        gameObject.SetActive(true);                                                                                                                                                       
        _shildcooldown = shieldCooldown;
        isShieldActive = true;
    }
}

