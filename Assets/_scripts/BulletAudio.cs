
/*##Space Attack##
 * Bullet Audio Script
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: 
 * This script is is sued fro binding an audio scourc to an event within the game.
 * The event in this case is the player fireing.
 * There is a serialized field for binding the audio clip to the game object.
 * THis is accessible to the user when they have attached this script to the audio object in unity.
 * 
 */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAudio : MonoBehaviour {
    //Input for the audio scource
    [SerializeField]
    private AudioClip shootSound;

    private AudioSource source;
   //Get the audio source
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {
        //play the audio scource whe the player fires.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.PlayOneShot(shootSound);
        }
	}
}
