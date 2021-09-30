using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishOfficer : MonoBehaviour
{
    [SerializeField] Transform attackPosition, enemyShipPos;
    [SerializeField] float moveDuration, rotateDuration, finishCameraMoveDuration, enemyShipMoveDuration;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "soldier")
        {
            AttackProcess();
        }
    }
    void AttackProcess() 
    {
        PlayerManager.Instance.halt = true;
        PlayerManager.Instance.playerActor.transform.DOMove(attackPosition.position, moveDuration).SetEase(Ease.Linear).OnComplete(()=>StartCoroutine(HeadingToTheEnemy()));
        
    }

    IEnumerator HeadingToTheEnemy() 
    {
        CameraFinishProcess();
        CallTheEnemyShip();
        yield return new WaitForSeconds(1.5f);
        foreach (Transform soldier in PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierContainer) 
        {
            soldier.DORotate(new Vector3(0f, 270f, 0f), rotateDuration).OnComplete(()=> StartCoroutine(StartAttacks()));
        }
    }

    void CameraFinishProcess() 
    {
        CameraManager.Instance.cameraFollowOfficer.FinishScene(finishCameraMoveDuration);
    }

    void CallTheEnemyShip() 
    {
        PlayerManager.Instance.playerActor.levelActor.enemyShip.GetComponent<EnemyShipActor>().CallTheEnemyShip(enemyShipPos.position, enemyShipMoveDuration);
    }

    IEnumerator StartAttacks() 
    {
        yield return new WaitForSeconds(1f);
        foreach (Transform soldier in PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierContainer)
        {
            soldier.GetComponent<SoldierActor>().ArrowShootAnim();
        }
        PlayerManager.Instance.playerActor.levelActor.enemyShip.GetComponent<EnemyShipActor>().StartAttacking();
    }

}
