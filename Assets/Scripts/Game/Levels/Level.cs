using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField]
    private LevelData levelData;
    [SerializeField]
    private TextMeshProUGUI levelNumberDisplay;


    public void SetLevelInfo(LevelData thisLevel, int levelNumber)
    {
        levelData = thisLevel;
        if (thisLevel)
        {
            levelNumberDisplay.text = levelNumber.ToString();
        }
    }

    public void OnClick()
    {
        levelData.LoadLevel();
    }
}