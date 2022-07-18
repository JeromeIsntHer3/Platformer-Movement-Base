using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField]
    private LevelHolder levelHolder;
    [SerializeField]
    private GameObject levelPrefab;
    [SerializeField]
    private GameObject levelPanel;
    

    void OnEnable()
    {
        SetUpLevels();
    }

    void OnDisable()
    {
        ClearLevels();
    }

    void SetUpLevels()
    {
        foreach(LevelData level in levelHolder.Levels)
        {
            GameObject temp = Instantiate(levelPrefab, levelPanel.transform.position, levelPanel.transform.rotation, levelPanel.transform);
            Level thisLevel = temp.GetComponent<Level>();
            if (thisLevel)
            {
                thisLevel.SetLevelInfo(level, levelHolder.Levels.IndexOf(level) + 1);
            }
        }
    }

    void ClearLevels()
    {
        for(int i = 0; i < levelPanel.transform.childCount;i++)
        {
            Destroy(levelPanel.transform.GetChild(i).gameObject);
        }
    }
}