using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArachnidBehaviour : MonoBehaviour
{
    public int aggroRange=10;
    public int kiteDistance =5;
    public bool walkToPlayer = true;
    public float timeBetweenAttacks;
    public bool isFacingLeft =true;
    public Animator animator;
    
    
    
    
    // Start is called before the first frame update

    void Start()
    {
        if (!isFacingLeft)
            transform.Rotate(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
