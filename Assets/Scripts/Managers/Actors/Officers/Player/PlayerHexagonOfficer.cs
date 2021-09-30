using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHexagonOfficer : MonoBehaviour
{
    [SerializeField] float edgeSize;
    public List<List<float>> hexagonPivotPoses = new List<List<float>>();

    [SerializeField] Transform character;
    [SerializeField] Transform testCube, testCubeContainer;
    float horizontalSinglePadding = 0f;
    public void DrawTheHexagonMap(int hexagonSize)
    {
        float verticalPadding = edgeSize * 3f;
        float horizontalPadding = 2 * (edgeSize * Mathf.Pow(3, (1.0f / 2.0f)));
        horizontalSinglePadding = (edgeSize * Mathf.Pow(3, (1.0f / 2.0f)));

        int horizontalHexagonStartAmount = 1 + ((2 * (hexagonSize - 1)) < 0 ? 0 : (2 * (hexagonSize - 1)));

        int levelCounter = 0;
        for (int horizontalLength = horizontalHexagonStartAmount; horizontalLength >= hexagonSize; horizontalLength--)
        {
            float yPos = levelCounter * verticalPadding;
            if (horizontalLength == horizontalHexagonStartAmount)
            {
                HorizontalBuild(horizontalLength, yPos);
            }
            else
            {
                HorizontalBuild(horizontalLength, yPos);
                HorizontalBuild(horizontalLength, -yPos);
            }
            levelCounter++;
        }

        void HorizontalBuild(int horizontalLength, float yPos) 
        {
            if (horizontalLength % 2 != 0)
            {
                List<float> tempHexagonPosCenter = new List<float>() { 0f, yPos };
                hexagonPivotPoses.Add(tempHexagonPosCenter);
                for (int i = 1; i < (horizontalLength / 2)+1; i++)
                {
                    float xPos = i * horizontalPadding;
                    List<float> hexagonPosRight = new List<float>() { xPos, yPos };
                    List<float> hexagonPosLeft = new List<float>() { -xPos, yPos };
                    hexagonPivotPoses.Add(hexagonPosRight);
                    hexagonPivotPoses.Add(hexagonPosLeft);
                }      
            }
            else
            {
                for (int i = 0; i < horizontalLength / 2; i++)
                {
                    float xPos = horizontalSinglePadding + (i * horizontalPadding);
                    List<float> hexagonPosRight = new List<float>() { xPos, yPos };
                    List<float> hexagonPosLeft = new List<float>() { -xPos, yPos };
                    hexagonPivotPoses.Add(hexagonPosRight);
                    hexagonPivotPoses.Add(hexagonPosLeft);
                }
            }           
        }
    }

    void PlaceTestCubes() 
    {
        int name = 0;
        foreach (List<float> pos in hexagonPivotPoses) 
        {
            Vector3 normalizedPos = new Vector3(pos[0], 0f,pos[1]);
            Transform tempTestCube = Instantiate(testCube, normalizedPos, Quaternion.identity, testCubeContainer);
            tempTestCube.name = "cube_" + name.ToString();
            name++;
        }
    }

    void EraseTheHexagon() 
    {
        hexagonPivotPoses.Clear();
        foreach (Transform cube in testCubeContainer)
        {
            Destroy(cube.gameObject, 0.1f);
        }       
    }

    #region Button
    [Title("Draw the Hexagon")]
    [Button("Draw the Hexagon", ButtonSizes.Large)]
    void ButtonDrawTheHexagonMap(int hexagonSÝze)
    {
        DrawTheHexagonMap(hexagonSÝze);
        PlaceTestCubes();
    }

    [Button("Erase the Hexagon", ButtonSizes.Large)]
    void ButtonEraseTheHexagonMap()
    {
        EraseTheHexagon();
    }
    #endregion
}
