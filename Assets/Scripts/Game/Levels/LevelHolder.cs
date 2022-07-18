using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSelector", menuName = "LevelSelector/LevelHolder")]
public class LevelHolder : ScriptableObject
{
    public List<LevelData> Levels;
}
