using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField]
    private LevelData[] levels;
    [SerializeField]
    private GameObject levelPrefab;
    [SerializeField]
    private GameObject levelPanel;
    

    void Awake()
    {
        SetUpLevels();
    }

    void SetUpLevels()
    {
        foreach(LevelData level in levels)
        {
            GameObject temp = Instantiate(levelPrefab, levelPanel.transform.position, levelPanel.transform.rotation, 
                levelPanel.transform);
            temp.transform.SetParent(levelPanel.transform);
            Level thisLevel = temp.GetComponent<Level>();
            if (thisLevel)
            {
                thisLevel.SetLevelInfo(level);
            }
        }
    }
}
