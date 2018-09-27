using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    public GameObject EnemySpawn;
  
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 1f;
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
            Instantiate(EnemySpawn, whereToSpawn, Quaternion.identity);
        }

        
    }
   
}
