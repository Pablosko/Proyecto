using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector2 newPosition;
    public GameObject newLevel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent.GetComponent<PlayerController>() != null) 
        {
            GameController.instance.player.transform.position = newPosition;
            GameController.instance.levelManager.LoadLevel(newLevel);
        }
    }
}
