/* Application Name: Space Attack
 * File Name: Main Menu
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: 
 * This script is attached to the play button on the start scene.
 * It is the first screen the user will see when the game starts or
 * when the game has ended and the user has entered and submitted their name.
 * When the play button is clicked it is bound to an event handler that will load the game at level one.
 * Refferences:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    //Play game function bound to the play game button on the menu scene.
	public void PlayGame()
    {
        //Set the initial value of lives to three
        Lives.livesValue = 3;
        //Set the initial score value to zero for the start of the game
        Score.scoreValue = 0;
        //Start the game at level 1 once the start game button is clicked/ tapped
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
