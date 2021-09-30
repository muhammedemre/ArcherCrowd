using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationOfficer : MonoBehaviour
{
    public int currentState = 0;
    public void IdleAnim() 
    {
        currentState = 0;
        PlayAnim(0);
    }

    public void RunAnim() 
    {
        currentState = 1;
        PlayAnim(1);
    }

    public void ArrowShootAnim()
    {
        currentState = 2;
        PlayAnim(2);
    }
    public void DanceAnim()
    {
        currentState = 3;
        PlayAnim(3);
    }

    void PlayAnim(int state)
    {     
        foreach (Transform soldier in PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierContainer)
        {
            soldier.GetComponent<SoldierActor>().animator.speed = (1 + (Random.Range(0f, 0.2f)));
            soldier.GetComponent<SoldierActor>().animator.SetInteger("State", state);
        }
    }
}
