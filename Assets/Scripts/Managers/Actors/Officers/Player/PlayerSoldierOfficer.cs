using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoldierOfficer : MonoBehaviour
{
    [SerializeField] PlayerHexagonOfficer playerHexagonOfficer;
    public Transform soldierContainer, soldier;
    public int soldierNumber = 1;
    int levelCapacity = 1;
    [SerializeField] int level = 1;
    public void StartProcess() 
    {
        DrawSoldiers();
    }

    public void DrawSoldiers() 
    {
        EraseTheHexagon();
        level = CalculateHexagonSize(1, soldierNumber);
        playerHexagonOfficer.DrawTheHexagonMap(level);
        PlaceSoldiers();
    }

    int CalculateHexagonSize(int currentLevel, int soldierNumber) 
    {     
        if (soldierNumber <= levelCapacity)
        {
            return currentLevel;
        }
        currentLevel++;
        levelCapacity = (levelCapacity+(6*(currentLevel-1)));
        return CalculateHexagonSize(currentLevel, soldierNumber);
    }

    void PlaceSoldiers()
    {
        int alreadyPlacedSoldierNumber = soldierContainer.childCount;
        int numberOfNewCreatingSoldier = soldierNumber - alreadyPlacedSoldierNumber;
        //print("numberOfNewCreatingSoldier 11: " + numberOfNewCreatingSoldier + " soldierNumber 11 : " + soldierNumber + " alreadyPlacedSoldierNumber : 11 " + alreadyPlacedSoldierNumber);

        for (int i = 0; i < alreadyPlacedSoldierNumber; i++)
        {
            List<float> pos = playerHexagonOfficer.hexagonPivotPoses[numberOfNewCreatingSoldier + i];
            Vector3 normalizedPos = new Vector3(pos[0], 0f, pos[1]);
            soldierContainer.GetChild(i).GetComponent<SoldierActor>().MoveTheTargetPoint(normalizedPos);
        }
        int name = alreadyPlacedSoldierNumber;
        //print("numberOfNewCreatingSoldier 22: " + numberOfNewCreatingSoldier + " soldierNumber 22 : "+ soldierNumber + " alreadyPlacedSoldierNumber : 22 " + alreadyPlacedSoldierNumber);
        for (int i = 0; i < numberOfNewCreatingSoldier; i++)
        {
            List<float> pos = playerHexagonOfficer.hexagonPivotPoses[i];
            Vector3 normalizedPos = new Vector3(pos[0], 0f, pos[1]);
            Transform tempSoldier = Instantiate(soldier, normalizedPos, Quaternion.identity, soldierContainer);
            tempSoldier.localPosition = normalizedPos;
            tempSoldier.name = "soldier_" + name.ToString();
            tempSoldier.GetComponent<SoldierActor>().playerActor = PlayerManager.Instance.playerActor.GetComponent<PlayerActor>();
            name++;
        }
    }
    void EraseTheHexagon()
    {
        levelCapacity = 1;
        playerHexagonOfficer.hexagonPivotPoses.Clear();
        /*foreach (Transform cube in soldierContainer)
        {
            Destroy(cube.gameObject, 0.1f);
        }*/
    }
    #region Button
    [Title("Calculate the hexagon size")]
    [Button("calculate the hexagonSize", ButtonSizes.Large)]
    void ButtonCalculateTheHexagonSize(int _soldierNumber)
    {
        levelCapacity = 1;
        level = 1;
        soldierNumber = _soldierNumber;
        StartProcess();
    }
    #endregion
}
