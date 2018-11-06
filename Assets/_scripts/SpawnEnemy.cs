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
    public Enemy enemy;
    
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 1.5f;
    float nextSpawn = 0.0f;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
       if(Time.time > nextSpawn)
        {
            
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-8.4f, 8.4f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }

        
        
    }
   
}
