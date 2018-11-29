using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    /*
     * 
     * This class is for keeping the background music going
     * while changing scenes.
    */
    void Awake()
    {   //Get GameObject with the audio attached
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        //IF the audio is playing more than once remove it
        if (objs.Length >1)
        {
               // Destroy the  audio
            Destroy(this.gameObject);            
        }
        //Keep the audio going through scenes
        DontDestroyOnLoad(this.gameObject);
    }
}
