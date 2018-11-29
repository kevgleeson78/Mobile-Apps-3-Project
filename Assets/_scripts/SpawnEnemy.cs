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
// Adapted From https://answers.unity.com/questions/810806/spawn-random-enemy.html
public class SpawnEnemy : MonoBehaviour {
    // The enemy prefab
    public Enemy enemy;
    //A random value for spawning from the center top of the screen
    float randX;
    // THis will be the random spawning point
    Vector2 whereToSpawn;
    //Set the rate of spawning
    public float spawnRate = 1.5f;
    //Time to the spawn
    float nextSpawn = 0.0f;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //check if the timer has run out
       if(Time.time > nextSpawn)
        {
            //increment the counter
            nextSpawn = Time.time + spawnRate;
            //The random spawn points of the enemies ae to the width of the screen minus the witdh of the ships
            randX = Random.Range(-8.4f, 8.4f);
            // Set the position of the random spawn point
            whereToSpawn = new Vector2(randX, transform.position.y);
            //Set the name of the enemy without (clone)
            enemy.name = "Enemy";
            //Create the enemy
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }

        
        
    }
   
}
