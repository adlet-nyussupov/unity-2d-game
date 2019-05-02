using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

    public Transform player;
    private Camera cm;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    Vector3 lp = new Vector3(0, 0, 0);
    
    // Use this for initialization
    void Start () {

        cm = GetComponent<Camera>();
        cm.transform.eulerAngles = lp;
    }
	
	// Update is called once per frame
	void Update () {
        cm.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        cm.transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
            Mathf.Clamp(transform.position.z, minCameraPos.z, minCameraPos.z));


        if (Collision.trigger)
        {
             lp = Vector3.Slerp(lp, new Vector3(0, 0, 0), Time.deltaTime * 4F);


        } else if(!Collision.trigger) { lp = Vector3.Slerp(lp, new Vector3(0, 0, 180), Time.deltaTime * 4F );
            
        }
        transform.eulerAngles = lp;

        Debug.Log(Collision.trigger);
        
        // cm.transform.rotation = Quaternion.Lerp (cm.transform.rotation, new Quaternion(0,0,180,0),Time.time*0.001F);



    }

}
