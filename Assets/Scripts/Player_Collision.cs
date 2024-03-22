using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    Player_Controller playerControllerScript;
    Feedback_Activation feedbackActivation;

    [SerializeField] AudioSource OuchSource;
    [SerializeField] AudioClip ouch;

    [SerializeField] private float push;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player_Controller").GetComponent<Player_Controller>();
        feedbackActivation = GameObject.Find("UI").GetComponent<Feedback_Activation>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            playerControllerScript.onFloor = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (feedbackActivation.playerInjurySound == true)
            {
                OuchSource.PlayOneShot(ouch);
            }
            else
            {

            }

            if (feedbackActivation.playerInjuryRecoil == true)
            {
                if (playerControllerScript.shootPointTransform.position.x > gameObject.transform.position.x)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-push, 0), ForceMode2D.Impulse);
                }
                else if (playerControllerScript.shootPointTransform.position.x < gameObject.transform.position.x)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(push, 0), ForceMode2D.Impulse);
                }
            }
            else
            {

            }            
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
