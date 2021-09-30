using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelActor : MonoBehaviour
{
    [SerializeField] float rotateSpeed, moveSpeed, distanceToAttack;
    [SerializeField] Rigidbody rb;
    bool notMoving = true;

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.playerActor != null)
        {
            if (Vector3.Distance(PlayerManager.Instance.playerActor.transform.position, transform.position) < distanceToAttack)
            {
                if (notMoving)
                {
                    notMoving = false;
                    rb.velocity = new Vector3(0f, 0f, -moveSpeed);
                }                
            }
            if (!notMoving)
            {
                transform.GetChild(0).Rotate(new Vector3(1, 0f, 0f), -rotateSpeed * Time.deltaTime);
            }
            
        }
        
        //transform.Translate(new Vector3(0f, 0f, -1f) * moveSpeed * Time.deltaTime);
    }
}
