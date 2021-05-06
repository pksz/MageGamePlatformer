using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    const float timegap = 0.25f;
    float timeGapBtwShots = 0f;
    Vector3 relativeMousePosition;
    public float offsetWeapon;

    // Update is called once per frame
    void Update()
    {
        /// find the coordinate of mouse relative to the player
        /// 
        relativeMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //rotation to be made

        float rotZ = Mathf.Atan2(relativeMousePosition.y , relativeMousePosition.x) * Mathf.Rad2Deg;


        




        
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
