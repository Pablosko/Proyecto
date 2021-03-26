using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [System.NonSerialized]
    public PlayerController player;
    void Awake()
    {
        instance = this;
        player = transform.Find("player").GetComponent<PlayerController>();
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
}
