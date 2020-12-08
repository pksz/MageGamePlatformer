using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    const float timegap = 0.25f;
    float timeGapBtwShots = 0f;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1")  && timeGapBtwShots<=0f)
        {
            Shoot();
        }
        if (timeGapBtwShots != 0)
        {
            timeGapBtwShots -= Time.deltaTime;
        }
    }



    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        timeGapBtwShots = timegap;

    }
}
