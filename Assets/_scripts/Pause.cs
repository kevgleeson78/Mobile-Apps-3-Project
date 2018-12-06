using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Application Name: Space Attack
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc:  A script to control pausing the game. bound to a click evewnt with button within the in game scenes.
 */
public class Pause : MonoBehaviour {

	// Update is called once per frame
	void Update () {
       

        
	}
   public void pausegame()
    {
        // if timeScale  = 1 the game is running
        if (Time.timeScale == 1)
        {
            // If Time scale is = 0 the game is paused
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }
}
