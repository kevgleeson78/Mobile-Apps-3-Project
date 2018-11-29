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
//Adapted From https://answers.unity.com/questions/647264/unity-2d-attacking.html
public class PlayerBullet : MonoBehaviour {
    //The speed of the player bullet set below
    float speed;
    private void Start()
    {
        //Set teh speed of the buullet
        speed = 8f;
    }
    private void Update()
    {
        // Animating the bullet
        Vector2 position = transform.position;
        //Moving the bullet upwards
        position = new Vector2(position.x, position.y + speed * Time.deltaTime );
        //Update the position of the bullet
        transform.position = position;
        //Set the max distance the bullet can travel. The hight of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        if (transform.position.y > max.y)
        {
            //If the bullet has travelled past the top of the screen
            //Destroy it..
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Check for collision between the enemy ship or bullet
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            //Remove the bullet
            Destroy(gameObject);

        }
    }
}
