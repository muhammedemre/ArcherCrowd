using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class PlayerManager : MonoBehaviour
{
    [Serializable]
    public class ReadyToPlayEnumBoolDict : SerializableDictionary<ReadyToPlayEnum, bool> { }
    public enum ReadyToPlayEnum 
    {
        playerManager_playerActor, inputManager_playerActor, playerMoveOfficer_Borders, playerMoveOfficer_platformWidth,
        cameraFollow_target, playerActor_gameLevelActor
    }

    public bool dead = true, halt = true, readyToPlay = false;
    public PlayerActor playerActor;
    public Transform arrowPool, arrow;
    [SerializeField] int arrowPoolSize;
    public List<Transform> arrowList = new List<Transform>(); 

    [SerializeField] ReadyToPlayEnumBoolDict readyToPlayStates = new ReadyToPlayEnumBoolDict();

    public static PlayerManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        print(Instance.gameObject.name + " is created");
    }
    public void StartProcess()
    {
        PrepareArrowPool();
    }
    public void Game_Init()
    {

    }
    public void InitLevel()
    {
    
    }
    public void Game_Start()
    {           
        halt = false;
        dead = false;

        playerActor.playerAnimationOfficer.RunAnim();
    }
    public void Game_Over()
    {
 
    }
    public void FinishLevel() 
    {
        halt = true;
        dead = true;
    }

    public void ReadyToPlayCheck(ReadyToPlayEnum receivedAssignmentCheck) 
    {
        readyToPlayStates[receivedAssignmentCheck] = true;

        foreach (ReadyToPlayEnum assignment in readyToPlayStates.Keys) 
        {
            if (!readyToPlayStates[assignment]) 
            {
                return;
            }
        }
        readyToPlay = true;
    }

    void PrepareArrowPool()
    {
        for (int i = 0; i < arrowPoolSize; i++)
        {
            Transform tempArrow = Instantiate(arrow, arrowPool);
            arrowList.Add(tempArrow);
            tempArrow.gameObject.SetActive(false);
        }
    }
}
