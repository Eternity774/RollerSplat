using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public List<LevelData> levelList = new List<LevelData>();
    private LevelData currentLevel;
    private int currentLevelNumber;

    private int allTiles;
    private int currentTiles;

    private GameObject currentLevelObj;

    public TextMeshProUGUI levelText;

    public static GameController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (!PlayerPrefs.HasKey("current_level"))
        {
            PlayerPrefs.SetInt("current_level", 0);
            currentLevelNumber = 0;
        }
        else
        {
            currentLevelNumber = PlayerPrefs.GetInt("current_level");
        }
        LoadLastLevel();
    }

    void LoadLastLevel()
    {
        currentLevel = levelList[currentLevelNumber];
        currentLevelObj = Instantiate(currentLevel.levelPrefab, Vector3.zero, Quaternion.identity);
        levelText.text = "Level " + (currentLevel.levelNumber + 1).ToString();
    }

    void SaveProgress()
    {
        PlayerPrefs.SetInt("current_level", currentLevel.levelNumber);
    }

    void LoadNextLevel()
    {
        if (currentLevel.levelNumber < levelList.Count - 1)
        {
            Destroy(currentLevelObj);
            currentLevel = levelList[currentLevel.levelNumber + 1];            
            currentLevelObj = Instantiate(currentLevel.levelPrefab, Vector3.zero, Quaternion.identity);
            levelText.text = "Level " + (currentLevel.levelNumber).ToString();
        }
        else
        {
            levelText.text = "Congratulations!!!";
        }
        SaveProgress();
        currentTiles = 0;
        allTiles = currentLevel.requiredCount;
    }

    public void CheckTile()
    {
        currentTiles++;
        if (currentTiles >= allTiles)
        {
            LoadNextLevel();
        }
    }
}
