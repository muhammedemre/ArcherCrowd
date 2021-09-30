using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonActor : MonoBehaviour
{
    [SerializeField] float shootFrequency, cannonBallSpeed;
    [SerializeField] Transform cannonBall, muzzle;
    float nextShoot;

    private void Start()
    {
        nextShoot = Time.time + shootFrequency;

    }
    private void Update()
    {
        ShootCheck();
    }

    void ShootCheck() 
    {
        if (nextShoot < Time.time)
        {
            nextShoot = Time.time + shootFrequency;
            Shoot();
        }
    }

    void Shoot() 
    {
        Transform tempCannonBall = Instantiate(cannonBall, muzzle.position, muzzle.rotation, transform);
        tempCannonBall.GetComponent<Rigidbody>().velocity = transform.forward * -cannonBallSpeed;
     
    }

    void ShootAnim() 
    {
        
    
    }
}
