using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu (fileName = "LevelSelector",menuName = "LevelSelector/LevelData")]
public class LevelData : ScriptableObject
{
    public string sceneName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}