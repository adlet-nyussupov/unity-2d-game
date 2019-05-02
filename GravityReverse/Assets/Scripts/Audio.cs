using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

    public static GameObject[] musicObject;
    public static AudioSource audioBg;
    public static bool destroyOnLoad = true;
    // Use this for initialization
    void Start () {
        
        audioBg = GetComponent<AudioSource>();
        
        musicObject = GameObject.FindGameObjectsWithTag("GameMusic");

        if (musicObject.Length == 1)
        {
            audioBg.Play();
        }
        else
        {
            for (int i = 1; i < musicObject.Length; i++)
            {
                Destroy(musicObject[i]);
            }
         }

    }



    void Awake()
    {
        if (destroyOnLoad)
        {

            DontDestroyOnLoad(this.gameObject);
        }

        


    }







    // Update is called once per frame
    void Update () {
        

    }





}
