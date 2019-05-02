using UnityEngine;
using System.Collections;

public class LevelFail : MonoBehaviour {


    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ReturnLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
