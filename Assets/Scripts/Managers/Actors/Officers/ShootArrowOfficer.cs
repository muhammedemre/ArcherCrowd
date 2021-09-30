using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootArrowOfficer : MonoBehaviour
{
    [SerializeField] List<float> attackRangePoints = new List<float>();
    [SerializeField] float height, flyDuration;

    void Attack() 
    {
        Transform tempArrow = PlayerManager.Instance.arrowList[0];
        tempArrow.DOMoveX(attackRangePoints[0], flyDuration);
        tempArrow.DOMoveY(height, flyDuration/2);
        tempArrow.DOMoveX(attackRangePoints[0], flyDuration);
    }
}
