/* Application Name: Space Attack
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: A script for updateing the player score.
 * A counter is also here to award an extra life for every 2000 points scored.
 * 
 */
using System;
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
    // Global variable to control the player lives update
    int _scoreCheck = 0;
    // Update is called once per frame
    void Update () {
       //Update the score
        score.text = "Score: " + scoreValue;

        //Check the players score to see if they get an extra life
        checkScore();
        

    }
    
    void checkScore()
    {
        //Condition for giving the player an extra life every 2000 points
        //And the player score is greater than one for the start of the game
        // And scoreCheck id equal to zero
        if (scoreValue % 2000 == 0 && scoreValue > 0 && _scoreCheck <= 0 )
        {
           //Increase the lives by one
            Lives.livesValue += 1;
            //Set the score check to 1
            _scoreCheck = 1;
        }
        //Reset the score check to 0
        else if(scoreValue % 2000 != 0 && _scoreCheck > 0)
        {
            _scoreCheck = 0;
        }
        
    }
    
}
