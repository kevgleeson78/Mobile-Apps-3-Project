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

public class PlayerSpawner : MonoBehaviour {
    /*
     * Adapted from https://www.youtube.com/watch?v=1oMOcL0iO4A     
     * 
     */
   

    [SerializeField]
    private GameObject playerPefab;
    GameObject playerInstance;
    float spawnTimer;
	// Use this for initialization
	void Start () {
        
        SpawnPlayer();
       
	}
	void SpawnPlayer()
    {
        spawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPefab, transform.position, Quaternion.identity);
        playerInstance.name = "Player";
        StartCoroutine("SetEnv");
    }
	// Update is called once per frame
	void Update () {
		if(playerInstance == null)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                SpawnPlayer();
               
            }
            
        }
	}
    private IEnumerator SetEnv()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
       
       // Debug.Log("Hit");
        yield return new WaitForSeconds(3F);
       // Debug.Log("2 Seconds past");
        Physics2D.IgnoreLayerCollision(9, 10, false);
       

    }
}
