/* Application Name: Space Attack
 * File Name: 
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: 
 * 
 * Refferences:
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {
    // Initail lives value 
    public static int livesValue = 3;
    // THe text game object on screen
    Text lives;
    // Use this for initialization
    void Start () {
       //Get the text component
        lives = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        //Update the lives the player has to the screen
        lives.text = "Lives: " + livesValue;
    }
}
