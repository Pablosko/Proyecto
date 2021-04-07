using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentLevel;
    public GameObject preLevel;
    public Transform levelTransorm;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void LoadLevel(GameObject newLevel) 
    {
        if (currentLevel != null)
            Destroy(currentLevel);
        preLevel.SetActive(false);
        Instantiate(newLevel, levelTransorm).transform.localPosition = Vector3.zero;
        currentLevel = newLevel;
    }
}
