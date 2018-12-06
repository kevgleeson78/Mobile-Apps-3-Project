/* Application Name: Space Attack
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * A script to hold the player score and name in the player prefs file.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Adapted From https://forum.unity.com/threads/leaderboard-script-using-playerprefs.257900/
public class Leaderboard : MonoBehaviour {
    //The max amount of visible entries on the screen
    public const int EntryCount = 10;
    
    public struct ScoreEntry
    {   //VAriables for the name and score of the user
        public string name;
        public int score;

        public ScoreEntry(string name, int score)
        {   //Set the name and score
            this.name = name;
            this.score = score;
        }
    }
    //List to hold the players score and name
    private static List<ScoreEntry> s_Entries;
    //List to hold the tp ten scores
    private static List<ScoreEntry> Entries
    {
        get
        {
            if (s_Entries == null)
            {
                //set entries to new llist
                s_Entries = new List<ScoreEntry>();
                //Function to load the top ten scores
                LoadScores();
            }
            //Return the list of scores
            return s_Entries;
        }
    }
    //Player prefs store locally on device
    private const string PlayerPrefsBaseKey = "leaderboard";

    private static void SortScores()
    {
        // Sort the scores from high to low using compareTo Method
        s_Entries.Sort((a, b) => b.score.CompareTo(a.score));
    }

    private static void LoadScores()
    {
        //Clear the list
        s_Entries.Clear();
        //Repopulate the list
        for (int i = 0; i < EntryCount; ++i)
        {
            //SGet the score from the playerprefs file
            ScoreEntry entry;
            entry.name = PlayerPrefs.GetString(PlayerPrefsBaseKey + "[" + i + "].name", "");
            entry.score = PlayerPrefs.GetInt(PlayerPrefsBaseKey + "[" + i + "].score", 0);
            //Add the scores to the list
            s_Entries.Add(entry);
        }

        SortScores();
    }

    private static void SaveScores()
    {
        for (int i = 0; i < EntryCount; ++i)
        {
            //Save the player score to the playerprefs file
            var entry = s_Entries[i];
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].name", entry.name);
            PlayerPrefs.SetInt(PlayerPrefsBaseKey + "[" + i + "].score", entry.score);
        }
    }

    public static ScoreEntry GetEntry(int index)
    {
        //Get the index of the current score enetred afte it has been sorted
        return Entries[index];
    }
    //Record fiunction
    public static void Record(string name, int score)
    {
        //.AD to the new score to the list
        Entries.Add(new ScoreEntry(name, score));
        //sort the scores 
        SortScores();
        //reomve anything outside the top 10
        Entries.RemoveAt(Entries.Count - 1);
        //save the scores and name to the player prefs.
        SaveScores();
    }
}
