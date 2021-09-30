using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyShipActor : MonoBehaviour
{
    [SerializeField] Transform enemyArmy, armySize;
    public void CallTheEnemyShip(Vector3 targetPos, float moveDuration) 
    {
        transform.DOMove(targetPos, moveDuration);
    }
    public void StartAttacking() 
    {
        foreach (Transform enemySoldier in enemyArmy)
        {
            enemySoldier.GetComponent<EnemySoldierActor>().AttackAnim();
        }
    }
}
