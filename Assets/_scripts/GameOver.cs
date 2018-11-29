/*##Space Attack##
 * Game over Script
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: 
 * This script is called when the players lives have reached zero.
 * The script displays and input filed for the players name to be entered.
 * Once the player has submitted their name the main menu scene is loaded.
 * 
 * Refferences:
 * Adapted From https://forum.unity.com/threads/leaderboard-script-using-playerprefs.257900/
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
    //Placeholder for the players name
    private string _nameInput = "";
    // Get the player score for storing in the leaderboard
    private string _scoreInput = Score.scoreValue.ToString();
    // init the input for the player name
    private void OnGUI()
    {
        GUIStyle font = new GUIStyle();
       int formWidth = 250;
        int formHeight = 200;
        // Start of the gui element With position and size
        GUILayout.BeginArea(new Rect(Screen.width /2 - (formWidth/2), Screen.height /2 , formWidth, formHeight));
        //Set the font size.
        font.fontSize = 20;
        //Set teh colour of the font.
        font.normal.textColor = Color.white;
        // Interface for reporting test scores.
        //Spaceing for the child elements
        GUILayout.Space(10);
        GUILayout.Label("Please enter your name: ", font);

        //Set default name if empty

        
      
            // Get the player score
            _nameInput = GUILayout.TextField(_nameInput);
      
       
        // A lable to display the player score to the user
        GUILayout.Label("Player Score: " + _scoreInput , font);
        // A button for submitting the player score and name
        // With a condition for a clicked event
        if (GUILayout.Button("Record"))
        {
            // local variable to hold the player score
            int score;
            //Parse the player score as it is a string data type 
            int.TryParse(_scoreInput, out score);
            if (_nameInput == "")
            {
                _nameInput = "Paul McGrath";
            }
            // Call the  Record function from the Leaderboard script
            Leaderboard.Record(_nameInput, score);

            // Reset for next input.
            _nameInput = "";
            _scoreInput = "0";
            //Load the main menu when the name and score have been submitted
            SceneManager.LoadScene(0);
        }

        //Close the GUI elements
        GUILayout.EndArea();
    }
}
