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
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Adapted from https://www.youtube.com/watch?v=QbqnDbexrCw
public class Score : MonoBehaviour {
    //Set the initial score to zero for the start of the game
    public static int scoreValue = 0;
    // The text game object on screen
    Text score;
	// Use this for initialization
	void Start () {
        //Get access tot he game object
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
       //Update the score
        score.text = "Score: " + scoreValue;
        
    }
    
}
