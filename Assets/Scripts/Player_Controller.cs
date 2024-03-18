using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Feedback_Activation feedbackActivation;

    #region VARIABLES
    [SerializeField]private float playerSpeed;
    [SerializeField] private float playerJumpSpeed;
    public bool onFloor = false;
    public bool isMoving;
    private float TimeFootstep = 0.2f;
    private float timeBetweenFootsteps;
    private KeyCode LastKeyPress;
    [SerializeField] private float timeUp;
    #endregion

    #region GAMEOBJECTS & ITS STUFF
    private GameObject player;
    private Rigidbody2D playerRB;
    private GameObject gun;
    [SerializeField] AudioSource footsteps;
    [SerializeField] AudioClip footstep;
    [SerializeField] Animator PlayerAnimator;
    [SerializeField] ParticleSystem dustParticles;
    [SerializeField] ParticleSystem dustParticlesLand;
    #endregion

    private void Start()
    {
        player = GameObject.Find("Player");
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        gun = GameObject.Find("Gun");
        feedbackActivation = GameObject.Find("UI").GetComponent<Feedback_Activation>();
    }

    private void Update()
    {
        PlayerMovement();
        Boundaries();
        Gun();
        Sound();
        DustParticlePlays();
        Landed();

        if (onFloor == false)
        {
            timeUp += 1;
        }
    }

    private void Boundaries()
    {
        if (player.transform.position.x < -8f)
        {
            player.transform.position = new Vector2(-8f, player.transform.position.y);
        }

        if (player.transform.position.x > 8f)
        {
            player.transform.position = new Vector2(8f, player.transform.position.y);
        }
    }

    private void Sound()
    {
        if (feedbackActivation.soundOn == true)
        {
            if (isMoving == true && onFloor == true)
            {
                if (Time.time - timeBetweenFootsteps >= TimeFootstep)
                {
                    footsteps.PlayOneShot(footstep);
                    timeBetweenFootsteps = Time.time;
                }
            }
            else
            {
                footsteps.Pause();
            }
        }
        else
        {

        }
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * playerSpeed * Time.deltaTime;
            isMoving = true;
            player.transform.localScale = new Vector3(1, 1, 1);

            if (onFloor == true)
            {
                PlayerAnimator.SetInteger("Movement", 1);
            }
            else if (onFloor == false)
            {
                PlayerAnimator.SetInteger("Movement", 0);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * playerSpeed * Time.deltaTime;
            isMoving = true;
            player.transform.localScale = new Vector3(-1, 1, 1);

            if (onFloor == true)
            {
                PlayerAnimator.SetInteger("Movement", 1);
            }
            else if (onFloor == false)
            {
                PlayerAnimator.SetInteger("Movement", 0);
            }
        }
        else
        {
            isMoving = false;
            PlayerAnimator.SetInteger("Movement", 0);
        }

        

        if (Input.GetKeyDown(KeyCode.Space) && onFloor == true)
        {
            playerRB.AddForce(Vector2.up * playerJumpSpeed, ForceMode2D.Impulse);
            PlayerAnimator.SetInteger("Movement", 2);
        }
    }

    private void Gun()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gun.transform.localScale = new Vector3(1, 0.1f, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gun.transform.localScale = new Vector3(-1, 0.1f, 1);
        }
    }

    private void DustParticlePlays()
    {
        if (Input.GetKeyDown(KeyCode.D) && onFloor == true)
        {
            dustParticles.Play();
        }
        else if (Input.GetKeyDown(KeyCode.A) && onFloor == true)
        {
            dustParticles.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && onFloor == true)
        {
            dustParticles.Play();
        }
    }

    private void Landed()
    {
        if (timeUp > 0)
        {
            if (onFloor)
            {
                Debug.Log("Landed");
                timeUp = 0;
                dustParticlesLand.Play();
            }
        }
    }
}
