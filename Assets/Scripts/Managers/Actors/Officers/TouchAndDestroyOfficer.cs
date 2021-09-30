using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndDestroyOfficer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "soldier")
        {
            Destroy(other.gameObject);
            PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierNumber -= 1;
        }
    }
}
