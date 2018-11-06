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
// Adapted From https://forum.unity.com/threads/leaderboard-script-using-playerprefs.257900/
public class LeaderboardTestGUI : MonoBehaviour {
   

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, 500, 500));

        // Display high scores!
        for (int i = 0; i < Leaderboard.EntryCount; ++i)
        {
            var entry = Leaderboard.GetEntry(i);
            GUILayout.Label(i +1 +" Name: " + entry.name + ", Score: " + entry.score);
        }

      

        GUILayout.EndArea();
    }
}
