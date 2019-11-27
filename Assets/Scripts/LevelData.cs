using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Level", order = 1)]
public class LevelData : ScriptableObject
{
    public int levelNumber;
    public GameObject levelPrefab;
    public int requiredCount;
}
