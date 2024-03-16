using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region VARIABLES
    [SerializeField]private float playerSpeed;
    [SerializeField] private float playerJumpSpeed;
    public bool onFloor = false;
    #endregion

    #region GAMEOBJECTS & ITS STUFF
    private GameObject player;
    private Rigidbody2D playerRB;
    private GameObject gun;
    #endregion

    private void Start()
    {
        player = GameObject.Find("Player");
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        gun = GameObject.Find("Gun Holder");
    }

    private void Update()
    {
        PlayerMovement();
        Boundaries();
        Gun();
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

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onFloor == true)
        {
            playerRB.AddForce(Vector2.up * playerJumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void Gun()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Debug.Log(mousePosition);

        if (mousePosition.x > player.transform.position.x)
        {
            gun.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (mousePosition.x < player.transform.position.x)
        {
            gun.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
