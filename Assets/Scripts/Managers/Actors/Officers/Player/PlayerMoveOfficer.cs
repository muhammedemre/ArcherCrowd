using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMoveOfficer : MonoBehaviour
{
    [SerializeField] PlayerActor playerActor;
    public float forwardMoveSpeed, horizontalMoveSpeed, smoothTime;
    [HideInInspector] public float platformWidth;
    public Transform leftBorderForPlayer, rightBorderForPlayer;
    Vector3 dampRefVector = Vector3.zero;
    public float forwardMoveSpeedAtStart;
    private void Start()
    {
        forwardMoveSpeedAtStart = forwardMoveSpeed;
    }
    public void MoveForward()
    {
        if (!PlayerManager.Instance.halt)
        {
            transform.Translate(transform.forward * forwardMoveSpeed * Time.deltaTime);
        }
    }

    public void PlayerHorizontalMoveSlide(float moveRate)
    {
        HorizontalMoveWithPositioning(moveRate);               
    }

    void HorizontalMoveWithPositioning(float moveRate) 
    {
        float newXPos = transform.position.x + (moveRate * horizontalMoveSpeed * platformWidth);
        newXPos = Mathf.Clamp(newXPos, leftBorderForPlayer.position.x, rightBorderForPlayer.position.x);
        Vector3 newPos = new Vector3(newXPos, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref dampRefVector, smoothTime);
    }

}
