using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    Feedback_Activation feedbackActivation;

    [SerializeField] private float speed;
    private float TimeFootstep = 0.5f;
    private float timeBetweenFootsteps;
    [SerializeField] AudioSource footsteps;
    [SerializeField] AudioClip footstep;
    private float TimeNoise = 5;
    private float timeBetweenNoises;
    [SerializeField] AudioSource zomSource;
    [SerializeField] AudioClip zom;
    [SerializeField] AudioClip zom2;
    [SerializeField] AudioSource shotSource;
    [SerializeField] AudioClip shot;
    [SerializeField] ParticleSystem blood;
    [SerializeField] Animator zomAnim;
    [SerializeField] GameObject player;

    private void Start()
    {
        feedbackActivation = GameObject.Find("UI").GetComponent<Feedback_Activation>();
    }

    private void Update()
    {
        Sound();

        if (transform.localScale == new Vector3(1,1,1))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (transform.localScale == new Vector3(-1, 1, 1))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (feedbackActivation.zombieAnimation == true)
        {
            zomAnim.enabled = true;
        }
        else
        {
            zomAnim.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            if (feedbackActivation.angryZombieSound == true)
            {
                zomSource.PlayOneShot(zom2);
            }
            else
            {

            }
            
            if (feedbackActivation.bloodParticles == true)
            {
                Vector3 pos = collision.transform.position;
                Instantiate(blood, pos, blood.transform.rotation);
            }
            else
            {

            }
            
            if (feedbackActivation.bulletHitSound == true)
            {
                shotSource.PlayOneShot(shot);
            }
            else
            {

            }

            if (transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    private void Sound()
    {
        if (feedbackActivation.zombieWalkSound == true)
        {
            if (Time.time - timeBetweenFootsteps >= TimeFootstep)
            {
                footsteps.PlayOneShot(footstep);
                timeBetweenFootsteps = Time.time;
            }            
        }
        else
        {

        }

        if (feedbackActivation.zombieSound == true)
        {
            if (Time.time - timeBetweenNoises >= TimeNoise)
            {
                zomSource.PlayOneShot(zom);
                timeBetweenNoises = Time.time;
            }
        }
        else
        {

        }
    }
}
