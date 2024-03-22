using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Collisions : MonoBehaviour
{
    Feedback_Activation feedbackActivation;

    [SerializeField] ParticleSystem wallDust;
    [SerializeField] AudioSource breaking;
    [SerializeField] AudioClip breakClip;

    private void Start()
    {
        feedbackActivation = GameObject.Find("UI").GetComponent<Feedback_Activation>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (feedbackActivation.gunHitParticles == true)
            {
                Vector3 pos = collision.transform.position;
                Instantiate(wallDust, pos, wallDust.transform.rotation);
            }
            else
            {

            }
            
            if (feedbackActivation.gunHitSound == true)
            {
                breaking.PlayOneShot(breakClip);
            }
            else
            {

            }            
        }
    }
}
