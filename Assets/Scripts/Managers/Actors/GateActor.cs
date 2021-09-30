using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateActor : MonoBehaviour
{
    //[SerializeField] float rightGatePoint, leftGatePoint;
    public GateType leftGateType, rightGateType;
    public int leftGateTypeValue, rightGateTypeValue;
    public Transform leftGate, rightGate;

    public enum GateType
    {
        multiplication, addition, substraction, division
    }


    public void CalculateIfLeftOrRightGateIsTriggered(Transform player)
    {
        if (player.position.x > 0) // right gate is triggered
        {
            GateProcess(rightGateType, rightGateTypeValue);
        }
        else
        {
            GateProcess(leftGateType, leftGateTypeValue);
        }
    }

    void GateProcess(GateType type, int value) 
    {
        switch (type)
        {
            case GateType.multiplication:
                PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierNumber *= value;
                StartCoroutine(DrawSoldierDelay());
                //PlayerManager.Instance.playerActor.playerSoldierOfficer.DrawSoldiers();
                break;
            case GateType.addition:
                PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierNumber += value;
                StartCoroutine(DrawSoldierDelay());
                //PlayerManager.Instance.playerActor.playerSoldierOfficer.DrawSoldiers();
                break;
            case GateType.substraction:
                for (int i = 0; i < value; i++)
                {
                    Destroy(PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierContainer.GetChild(i).gameObject);
                }
                PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierNumber -= value;
                StartCoroutine(DrawSoldierDelay());
                //PlayerManager.Instance.playerActor.playerSoldierOfficer.DrawSoldiers();
                break;
            case GateType.division:

                int newSoldierAmount = PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierContainer.childCount / value;
                int subAmount = PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierContainer.childCount - newSoldierAmount;
                for (int i = 0; i < subAmount; i++)
                {
                    Destroy(PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierContainer.GetChild(i).gameObject);
                }
                PlayerManager.Instance.playerActor.playerSoldierOfficer.soldierNumber -= subAmount;
                StartCoroutine(DrawSoldierDelay());
                //PlayerManager.Instance.playerActor.playerSoldierOfficer.DrawSoldiers();
                break;
            default:
                break;
        }
    }

    IEnumerator DrawSoldierDelay() 
    {
        yield return new WaitForEndOfFrame();
        PlayerManager.Instance.playerActor.playerSoldierOfficer.DrawSoldiers();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "soldier")
        {
            GetComponent<Collider>().enabled = false;
            CalculateIfLeftOrRightGateIsTriggered(other.transform);
        }
    }

    void SetGateText(GateType type, Transform gate, int value) 
    {
        Transform curtainTextBox = gate.GetComponent<CurtainActor>().textBox;
        foreach (Transform textObj in curtainTextBox)
        {
            textObj.gameObject.SetActive(false);
        }
        switch (type)
        {
            case GateType.multiplication:
                curtainTextBox.GetChild(0).gameObject.SetActive(true);
                curtainTextBox.GetChild(0).GetComponent<TextMeshPro>().text = "x " + value.ToString();
                break;
            case GateType.addition:
                curtainTextBox.GetChild(1).gameObject.SetActive(true);
                curtainTextBox.GetChild(1).GetComponent<TextMeshPro>().text = "+ " + value.ToString();
                break;
            case GateType.substraction:
                curtainTextBox.GetChild(2).gameObject.SetActive(true);
                curtainTextBox.GetChild(2).GetComponent<TextMeshPro>().text = "- " + value.ToString();
                break;
            case GateType.division:
                curtainTextBox.GetChild(3).gameObject.SetActive(true);
                curtainTextBox.GetChild(3).GetComponent<TextMeshPro>().text = "/ " + value.ToString();
                break;
            default:
                break;
        }
    }

    #region Button

    [Title("Set the gates values and then Invoke")]
    [Button("Set gates", ButtonSizes.Large)]
    void ButtonCameraPositioner()
    {
        SetGateText(leftGateType, leftGate, leftGateTypeValue);
        SetGateText(rightGateType, rightGate, rightGateTypeValue);
    }
    #endregion Button
}
