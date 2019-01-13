/*
 * Player Movement Script 
 * 
 * @author johnf2
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Initial Scripts for player movemet
    //TODO: change movement script to use Time.deltaTime when taught
    public int playerSpeed = 5;
    public int playerJumpPower = 315;

    private float xMovement;

    //grounded boolean, used to know if object is grounded 
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initial Test");
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }

    //player movement function, called on every update 
    void playerMove()
    {
        //gets direction on the x-axis based on input 
        xMovement = Input.GetAxis("Horizontal");

        //calls jump() if jump button is pressed 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("jump being pressed");
            Jump();
        }

        if (xMovement < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (xMovement > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //moves the player object left or right by giving it velocity 
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMovement * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    //player jumping method
    void Jump()
    {
        //"jumps" by adding force to the Rigidbody2D component 
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    //Listener Function
    //when player object collides with an onbject this function with call
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //simple way to see what object the player has collided with 
        Debug.Log("player has collide with " + collision.collider.name);

        //if the player object collides with the ground, then isGrounded is set back to true 
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }



}
