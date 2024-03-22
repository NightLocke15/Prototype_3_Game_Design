using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Feedback_Activation feedbackActivation;
    public ScreenShake screenShake;

    #region VARIABLES
    [SerializeField]private float playerSpeed;
    [SerializeField] private float playerJumpSpeed;
    public bool onFloor = false;
    public bool isMoving;
    private float TimeFootstep = 0.2f;
    private float timeBetweenFootsteps;
    [SerializeField] private float timeUp;
    [SerializeField] private float bulletSpeed;
    public float push;
    #endregion

    #region GAMEOBJECTS & ITS STUFF
    private GameObject player;
    private Rigidbody2D playerRB;
    private GameObject gun;
    [SerializeField] AudioSource footsteps;
    [SerializeField] AudioClip footstep;
    [SerializeField] AudioSource JumpSource;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioSource LandSource;
    [SerializeField] AudioClip land;
    [SerializeField] AudioSource ShotSource;
    [SerializeField] AudioClip shot;
    [SerializeField] Animator PlayerAnimator;
    [SerializeField] Animator GunAnimator;
    [SerializeField] ParticleSystem dustParticles;
    [SerializeField] ParticleSystem dustParticlesLand;
    [SerializeField] ParticleSystem gunParticles;
    [SerializeField] private GameObject bullet;
    public Transform shootPointTransform;
    [SerializeField] private GameObject gunParticleHolder;
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
        PlayerShooting();

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
        //Footstep Sounds
        if (feedbackActivation.playerWalkSound == true)
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (feedbackActivation.playerJumpSound == true)
            {
                JumpSource.PlayOneShot(jump);
            }
            else
            {

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (feedbackActivation.gunSound == true)
            {
                ShotSource.PlayOneShot(shot);
            }
            else
            {

            }
        }
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * playerSpeed * Time.deltaTime;
            isMoving = true;
            player.transform.localScale = new Vector3(1, 1, 1);
            shootPointTransform.rotation = Quaternion.Euler(0, 0, 0);

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
            shootPointTransform.rotation = Quaternion.Euler(0, 0, 180);

            if (feedbackActivation.playerAnimation == true)
            {
                PlayerAnimator.enabled = true;

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
                PlayerAnimator.enabled = false;
            }
        }
        else
        {
            isMoving = false;

            if (feedbackActivation.playerAnimation == true)
            {
                PlayerAnimator.enabled = true;

                PlayerAnimator.SetInteger("Movement", 0);
            }
            else
            {
                PlayerAnimator.enabled = false;
            }

        }

        

        if (Input.GetKeyDown(KeyCode.Space) && onFloor == true)
        {
            playerRB.AddForce(Vector2.up * playerJumpSpeed, ForceMode2D.Impulse);

            if (feedbackActivation.playerAnimation == true)
            {
                PlayerAnimator.enabled = true;

                PlayerAnimator.SetInteger("Movement", 2);
            }
            else
            {
                PlayerAnimator.enabled = false;
            }
        }
    }

    private void Gun()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gun.transform.localScale = new Vector3(1, 0.1f, 1);
            gunParticleHolder.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gun.transform.localScale = new Vector3(-1, 0.1f, 1);
            gunParticleHolder.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    private void DustParticlePlays()
    {
        if (Input.GetKeyDown(KeyCode.D) && onFloor == true)
        {
            if (feedbackActivation.playerWalkParticles == true)
            {
                dustParticles.Play();
            }
            else
            {

            }
        }
        else if (Input.GetKeyDown(KeyCode.A) && onFloor == true)
        {
            if (feedbackActivation.playerWalkParticles == true)
            {
                dustParticles.Play();
            }
            else
            {

            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && onFloor == true)
        {
            if (feedbackActivation.playerWalkParticles == true)
            {
                dustParticles.Play();
            }
            else
            {

            }
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
                if (feedbackActivation.playerLandingParticles == true)
                {
                    dustParticlesLand.Play();
                }
                else
                {

                }

                if (feedbackActivation.screenShake == true)
                {
                    screenShake.Shake(0.2f);
                }
                else
                {

                }
                
                if (feedbackActivation.playerLandingSound == true)
                {
                    LandSource.PlayOneShot(land);
                }
                else
                {

                }
                
            }
        }
    }

    private void PlayerShooting()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var bulletObject = Instantiate(bullet, shootPointTransform.position, shootPointTransform.rotation);
            bulletObject.GetComponent<Rigidbody2D>().velocity = shootPointTransform.right * bulletSpeed;
            
            if (feedbackActivation.shootingParticles == true)
            {
                gunParticles.Play();
            }
            else
            {

            }
            
            if (feedbackActivation.gunAnimation == true)
            {
                GunAnimator.SetTrigger("Shoot");
            }
            else
            {

            }
            

            if (feedbackActivation.gunRecoil == true)
            {
                if (shootPointTransform.position.x > player.transform.position.x)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-push, 0), ForceMode2D.Impulse);
                }
                else if (shootPointTransform.position.x < player.transform.position.x)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(push, 0), ForceMode2D.Impulse);
                }
            }
            else
            {

            }
        }
    }
}
