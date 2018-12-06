/* Application Name: Space Attack
 * File Name: 
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: A script to display the leadboard from teh Leaderboard script.
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Adapted From https://forum.unity.com/threads/leaderboard-script-using-playerprefs.257900/
public class LeaderboardTestGUI : MonoBehaviour {
    //Fro displaying the name and score
    string scoreValue = "";
    //Get the gameobject text
    Text score;
    
    // Use this for initialization
    void Start()
    {
        // Display high scores! top 10
        for (int i = 0; i < Leaderboard.EntryCount; ++i)
        {

            //Get the entries from the leaderbord file
            var entry = Leaderboard.GetEntry(i);
            // Stroe each record in a string for displaying
            scoreValue += i + 1 + " Name: " + entry.name + ", Score: " + entry.score +"\n";
            //Get acces to the onscreen text game object
            score = GetComponent<Text>();
            //Set each player name and score to teh text object
            score.text = scoreValue;


            //Debug.Log(scoreValue);
        }
    }

    
}
