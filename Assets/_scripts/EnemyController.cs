
/* Application Name: Space Attack
 * File Name: 
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: 
 * 
 * Refferences:
 * https://www.youtube.com/watch?v=2WlY0dL5Qrg&list=PLRN2Qvxmju0Mf1GB1hXsT-x1GQJQ0pwE0&index=3
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
   public static int shipDistCount = 0;
    //Var to hold enemy speed
    float speed;
    // Use this for initialization
    void Start()
    {   //Set speed
        speed = 1f + BossController.difficluty;
    }

    // Update is called once per frame
    void Update()
    {
        //load the boss level
        loadBoss();
        
        //Get the current position of the enemy ship
        Vector2 position = transform.position;
        //Get next position in the frame
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        //Update the new position
        transform.position = position;
        //Get the bottom of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //Destroy the enemy ship if it gets to the bottom of the screen.
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Check for collisions of player bullet
        if (col.tag == "PlayerBulletTag")
        {
            //Destroy the enemy ship
            Destroy(gameObject);
            //Increment the player score
            Score.scoreValue +=  10;
            // A counter for the amount of ships distroyed
            shipDistCount += 1;
        }
        //If hte player ship collides with the enemy ship
        if (col.tag == "PlayerShipTag")
        {
            //Distroy the enemy ship
            Destroy(gameObject);
        }
    }
    private void loadBoss()
    {
        //Boss level loads every 5 ships destroyed and noty at the start of a new level
        if (shipDistCount %5 == 0 && shipDistCount != 0)
        {
            // load the boss scene
            SceneManager.LoadScene(2);
        }
    }
}
