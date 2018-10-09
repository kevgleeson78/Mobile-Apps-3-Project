using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* An empty game object is placed in front of the enemy ship to hold
 * THe enemy bullet prefab.
 * This script is attached to the enemy gun game aoject.
 * This object is in turh a child of the enemy ship object.
 * Both objects are a complete prefab.* 
 */
public class EnemyGun : MonoBehaviour {
    //Enemies Bullet Prefab
    public GameObject EnemyBullet;
	// Use this for initialization
	void Start () {
        //First paramater for Function name
        //Second Parameter for when the ship stsrts to shoot
        //Third paramater for the time till next shot.
        InvokeRepeating("FireEnemyBullet", 1f, 4f);

    }
     // Update is called once per frame
    void Update () {
      
    }
    void FireEnemyBullet()
    {
        //Get the Player Ship Object
        GameObject playerShip = GameObject.Find("Player");
        //If the player has not been killed 
        if(playerShip != null)
        {
            //Make instance of enemyBullet prefab
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);
            //Get Position of the bullet
            bullet.transform.position = transform.position;

            //Get the direction of the bullet to be fired
            Vector2 direction = playerShip.transform.position - bullet.transform.position;
            //Set the direction of the enemy bullet from the enemy bullet script.
            bullet.GetComponent<EnemyBullet>().setDirection(direction);
        }
    }
}
