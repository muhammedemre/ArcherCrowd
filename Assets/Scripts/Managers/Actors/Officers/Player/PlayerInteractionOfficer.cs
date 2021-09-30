using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionOfficer : MonoBehaviour
{
    [SerializeField] PlayerActor playerActor;
    public bool triggerBusy = false;

    private void OnTriggerEnter(Collider other)
    {
        
    }

    
}
