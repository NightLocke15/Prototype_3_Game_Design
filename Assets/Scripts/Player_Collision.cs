using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    Player_Controller playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player_Controller").GetComponent<Player_Controller>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            playerControllerScript.onFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            playerControllerScript.onFloor = false;
        }
    }
}
