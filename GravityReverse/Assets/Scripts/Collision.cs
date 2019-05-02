using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {



    // Use this for initialization


    public Camera cam;
    public static bool trigger = true;
    public static bool isGrounded;
    public GameObject audioL1Destroy;
    public GameObject winMenu;
    public AudioSource winAudio;
    public GameObject failMenu;
    public GameObject killPlayer;



    void Start () {

        winMenu.SetActive(false);
        failMenu.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(isGrounded);
       


    }

    void OnTriggerEnter2D(Collider2D other)
        {
        
       
        
        if (other.gameObject.tag == "Star")
        {
            if(trigger == true)
            {
                trigger = false;
            } else { trigger = true; };

            Destroy(other.gameObject);
            // cam.transform.Rotate(new Vector3(180,180));
           
            Physics2D.gravity = -Physics2D.gravity;
            

        }
        
        if (other.gameObject.tag == "Thorn")
        {

            Destroy(killPlayer);
            failMenu.SetActive(true);
            
          
            
        
           // cam.transform.Rotate(new Vector3(0, 0));
            

            if (trigger == false)
            {
                Physics2D.gravity = -Physics2D.gravity;
            }

            trigger = true;




        }
        
        if(other.gameObject.tag == "Teleport")
        {

            Time.timeScale = 0;
            

            if (Audio.musicObject.Length == 1)
            {
                Audio.audioBg.Stop();
            } else
            {

                Audio.destroyOnLoad = false;
                
                Audio.musicObject[0].SetActive(false);

            }
            winMenu.SetActive(true);
            winAudio.Play();

            

        }

   

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {

            isGrounded = false;

        }

    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    


}
