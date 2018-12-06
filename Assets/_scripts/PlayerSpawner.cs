/* Application Name: Space Attack
 * File Name: 
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: A script to control the spawning of the player ship.
 * The spawner has a timer to stop respawning right away.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    /*
     * Adapted from https://www.youtube.com/watch?v=1oMOcL0iO4A     
     * 
     */
   
    //Add the player prefab
    [SerializeField]
    private GameObject playerPefab;
    //Get an instance of the player to respawn after destroyed
    GameObject playerInstance;
    // A timer for respawning
    float spawnTimer;
	// Use this for initialization
	void Start () {
        //Spawn the player
        SpawnPlayer();
       
	}
	void SpawnPlayer()
    {
        
        // One second delay
        spawnTimer = 1;
        //New player instance
        playerInstance = (GameObject)Instantiate(playerPefab, transform.position, Quaternion.identity);
        //Remove the (Clone) from the name
        playerInstance.name = "Player";
        //Function to set invulnerability
        StartCoroutine("SetEnv");
    }
	// Update is called once per frame
	void Update () {
        //'Check if the player does not exist
		if(playerInstance == null)
        {
            //Set the timer 
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                //Spawn the player one the timer has reached zero
                SpawnPlayer();
               
            }
            
        }
	}
    private IEnumerator SetEnv()
    {
        //Ignore collisions between enemy bullets and ships on their respective layers.
        Physics2D.IgnoreLayerCollision(9, 10, true);

        // Debug.Log("Hit");
        //Set invulnerability for three seconds
        yield return new WaitForSeconds(3F);
       // Debug.Log("2 Seconds past");
       //Trun back on collisions
        Physics2D.IgnoreLayerCollision(9, 10, false);
       

    }
}
