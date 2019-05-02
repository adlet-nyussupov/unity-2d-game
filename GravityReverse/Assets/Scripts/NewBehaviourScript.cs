using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class NewBehaviourScript : MonoBehaviour {
    private Rigidbody2D rb;
    private ForceMode2D mode;
    public Vector2 speedMove = new Vector2(700, 0);
    public Vector2 speedMoveRev = new Vector2(-700, 0);
    public Vector2 jumpForce = new Vector2(0, 10000);
    public Vector2 jumpForceRev = new Vector2(0, -10000);
    float moveSpeed = 2000;
    Vector2 maxSpeed = new Vector2(2, 0);
    Canvas right;
    Canvas left;
    Canvas jump;


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        mode = new ForceMode2D();


        




    }

    
	
	// Update is called once per frame
	void FixedUpdate () {
        move();
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -10, 10), Mathf.Clamp(rb.velocity.y, -16, 16));




    }

    void move()
    {

            if (Input.GetKey(KeyCode.D) )
            {
                if (Collision.trigger)
                {
                    rb.AddForce(speedMove, mode);

                }
                else rb.AddForce(speedMoveRev, mode);

            }


            if (Input.GetKey(KeyCode.A) )
            {
                if (Collision.trigger)
                {
                    rb.AddForce(speedMoveRev, mode);

                }
                else  { rb.AddForce(speedMove, mode); }
            }


            if (Input.GetKeyDown(KeyCode.Space) /*&& Collision.isGrounded*/ )
            {
                if (Collision.trigger)
                {
                    rb.AddForce(jumpForce, mode);
                }
                else { rb.AddForce(jumpForceRev, mode); }
            }

        
    }
  


}
