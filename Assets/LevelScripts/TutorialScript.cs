using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToRemove;

    void Awake()
    {
        foreach(GameObject go in objectsToRemove)
        {
            go.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}