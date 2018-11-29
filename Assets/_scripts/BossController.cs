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
using UnityEngine.SceneManagement;
//Adapted from https://forum.unity.com/threads/left-and-right-enemy-moving-in-2d-platformer.364716/
public class BossController : MonoBehaviour
{
    //Var to hold enemy speed
    float speed;
    //Moving right
    private bool dirRight = true;
    //Get the scene index
    private int sceneIndex;
    // The boss health
    public static float health;
    //For increment the difficulty
    public static float difficluty = 0f;
    void Start()
    {   //Set speed
        speed = 2f;
        //Set the health of the boss
        health = 10;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    


    void Update()
    {
        //Get the position of the left and right of the screen
        //For moving the boss
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        //Account for the width of the boss ship
        max.x = max.x - 4f;
        //Offset to allow for the width of the ship sprite to right of screen
        min.x = min.x + 4f;
        //If moving right
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            //Move left
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= max.x)
        {
            dirRight = false;
        }

        if (transform.position.x <= min.x)
        {
            dirRight = true;
        }
        //IF the boss has been destroyed
        if(health <= 0)
        {
            //increment the destroyed ship counter
            EnemyController.shipDistCount += 1;
            //increse the dificulty
            difficluty += .9f;
            //Destroy teh boss ship
            Destroy(gameObject);
            //Load the first scene
            SceneManager.LoadScene(1);
        }
    }
        private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBulletTag")
        {
            //Decrement the boss health when hit
            health -= .1f;
            //Increment the player score
            Score.scoreValue = Score.scoreValue + 10;
        }
        if (col.tag == "PlayerShipTag")
        {
            //If the player ship collides with the player ship 
            //decement the boss health
            health -= .1f;
        }
    }

}
