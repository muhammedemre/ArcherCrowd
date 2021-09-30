using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierActor : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform muzzle;
    public void AttackAnim() 
    {
        animator.speed = 1;
        animator.SetInteger("State", 2);
    }
}
