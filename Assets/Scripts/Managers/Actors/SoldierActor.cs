using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoldierActor : MonoBehaviour
{
    [SerializeField] float moveDuration;
    public List<float> soldierPos;
    public Animator animator;
    public PlayerActor playerActor;


    private void Start()
    {
        StartAnimProcess();
        animator.SetInteger("State", PlayerManager.Instance.playerActor.playerAnimationOfficer.currentState);
    }
    public void MoveTheTargetPoint(Vector3 targetPoint) 
    {
        soldierPos = new List<float>() { targetPoint.x, targetPoint.z };
        transform.DOLocalMove(targetPoint, moveDuration);
    }
    public void IdleAnim()
    {
        animator.SetInteger("State", 0);
    }
    public void RunAnim()
    {
        animator.SetInteger("State", 1);
    }
    public void ArrowShootAnim()
    {
        animator.SetInteger("State", 2);
    }
    public void DanceAnim()
    {
        animator.SetInteger("State", 3);
    }

    void StartAnimProcess() 
    {
        animator.speed = (1 + (Random.Range(0f, 0.2f)));
    }
}
