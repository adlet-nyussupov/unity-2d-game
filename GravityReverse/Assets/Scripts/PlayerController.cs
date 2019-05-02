using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D RigidbodyPlayer;
    private bool isLeftPressed = false;
    private bool isRightPressed = false;
    private bool isJumpPressed = false;
    public float moveSpeed;
    public float jumpStrength;
    public Image imgLeft;
    public Image imgRight;
    public Image imgJump;
    public Text txtLeft;
    public Text txtRight;
    public Text txtJump;
    private bool dontShowAgainIU;
    


    // Use this for initialization
    void Start () {
/*
        imgLeft = GetComponent<Image>();
        imgRight = GetComponent<Image>();
        imgJump = GetComponent<Image>();
        */
        


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isLeftPressed)
        {
            imgLeft.color = new Color(imgLeft.color.r, imgLeft.color.g, imgLeft.color.b, 0.02F);
            dontShowAgainIU = true;
            if (Collision.trigger)
            {
                RigidbodyPlayer.AddForce(new Vector2(-moveSpeed, 0));
            } else
                RigidbodyPlayer.AddForce(new Vector2(moveSpeed, 0));
            
        }
        else { imgLeft.color = new Color(imgLeft.color.r, imgLeft.color.g, imgLeft.color.b, 0.01F); }


        if (isRightPressed)
        {
            imgRight.color = new Color(imgLeft.color.r, imgLeft.color.g, imgLeft.color.b, 0.02F);
            dontShowAgainIU = true;
            if (Collision.trigger)
            {
                RigidbodyPlayer.AddForce(new Vector2(moveSpeed, 0));
            } else
                RigidbodyPlayer.AddForce(new Vector2(-moveSpeed, 0));
        }
        else { imgRight.color = new Color(imgLeft.color.r, imgLeft.color.g, imgLeft.color.b, 0.01F); }


        if (isJumpPressed)
        {
            imgJump.color = new Color(imgLeft.color.r, imgLeft.color.g, imgLeft.color.b, 0.02F);
            dontShowAgainIU = true;
            if (Collision.isGrounded)
            {
                if (Collision.trigger)
                {
                    RigidbodyPlayer.AddForce(new Vector2(0, jumpStrength));
                }
                else
                    RigidbodyPlayer.AddForce(new Vector2(0, -jumpStrength));

            }
        }
        else { imgJump.color = new Color(imgLeft.color.r, imgLeft.color.g, imgLeft.color.b, 0.01F); }


        if (dontShowAgainIU)
        {
            txtLeft.color = new Color(imgLeft.color.r, imgLeft.color.g, imgLeft.color.b, 0F);
            txtRight.color = new Color(imgLeft.color.r, imgLeft.color.g, imgLeft.color.b, 0F);
            txtJump.color = new Color(imgLeft.color.r, imgLeft.color.g, imgLeft.color.b, 0F);
        }


        RigidbodyPlayer.velocity = new Vector2(Mathf.Clamp(RigidbodyPlayer.velocity.x, -10, 10), Mathf.Clamp(RigidbodyPlayer.velocity.y, -16, 16));

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
    public void moveLeft()
    {
        isLeftPressed = true;
    }
    public void moveLeftStop()
    {
        isLeftPressed = false;
    }

    public void moveRight()
    {
        isRightPressed = true;
    }
    public void moveRightStop()
    {
        isRightPressed = false;
    }

    public void jump()
    {
        isJumpPressed = true;
        
    }
    public void jumpStop()
    {
        isJumpPressed = false;

    }



}
