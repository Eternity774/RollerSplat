using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevelGenerator : MonoBehaviour
{
    public int xLenght, zLenght;
    public bool[,] levelArray = new bool[5, 5];
    public GameObject roadCube;
    public GameObject wallCube;


    public void GenerateBaseLevel()
    {
        GameObject parent = new GameObject("GeneratedLevel");

        int xStartPoint = (xLenght % 2 == 0) ? ((xLenght / 2) * -1) : ((xLenght - 1) / 2) * -1;
        int zStartPoint = (zLenght % 2 == 0) ? ((zLenght / 2) * -1) : ((zLenght - 1) / 2) * -1;

        int xPos = xStartPoint;
        int zPos = zStartPoint;

        for (int i = 0; i < zLenght; i++)
        {
            zPos++;
            xPos = xStartPoint;
            for (int j = 0; j < xLenght; j++)
            {
                if (levelArray[j, i])
                {
                    Instantiate(wallCube, new Vector3(xPos, 0, zPos), Quaternion.identity, parent.transform);
                }
                else
                {
                    Instantiate(roadCube, new Vector3(xPos, 0, zPos), Quaternion.identity, parent.transform);
                }
                xPos++;
            }
        }
    }

}
