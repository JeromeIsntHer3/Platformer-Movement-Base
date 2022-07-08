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
    

    public void SetLevelInfo(LevelData thisLevel)
    {
        levelData = thisLevel;
        if (thisLevel)
        {
            levelNumberDisplay.text = levelData.levelNumber;
        }
    }

    public void OnClick()
    {
        levelData.LoadLevel();
    }
}