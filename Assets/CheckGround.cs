using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameController.instance.player.grounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        GameController.instance.player.grounded = false;
    }
}
