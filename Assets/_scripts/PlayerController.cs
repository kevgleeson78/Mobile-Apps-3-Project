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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
   
    //Get acces to the player bullet prefab
    public GameObject PlayerBullet;
    // For positioning of the bullet at the top of the spaceship
    public GameObject BulletPosition;

    public float fireRate = 1f;
    private float nextFire = 0;
    // The speed the ship travels
    public Button myButton;
    public float speed = 1;
    public VirtualJoystick moveJoystick;
    // Update is called once per frame
    void Update () {
       
        // TO set the direction of the ship
        Vector2 direction =  Vector2.zero;
        
        // Condition to chseck for which type of input the user is using
        //If the joystick has been activated by tapping the image set direction to the joysticks inputDirection
        if (moveJoystick.Inputdirection != Vector2.zero)
        {
            direction = moveJoystick.Inputdirection;
            
        }
        //If the keyboard buttons have been pressed set the direction to horizontal and vertical
        else
        {
            // x,y for getting the verticle and horizontal movements of the ship
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxis("Vertical");
           
        }
        // The move function for the movement direction of the ship
        Move(direction);


        // Input for fire of bullet

        if (Input.GetKeyDown("space") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
            // Play audio when the bullet is fired
           // GetComponent<AudioSource>().Play();
            // Instantiate the bullet prefab
           // GameObject bullet = (GameObject)Instantiate(PlayerBullet);
            // Set the bullets position when fired
          //  bullet.transform.position = BulletPosition.transform.position;
        }
        
       
    }
    void Start()
    {
        // Action listener for the ui button clicked
        //There was a problem adding a clicked event to a perfab.
        //The bullets were not staying with th ship when the ship moved from its starting point.
        // Solution adapted from https://stackoverflow.com/questions/42306703/unity-button-not-shooting-projectile-properly
        
            myButton.onClick.AddListener(shoot);
    }

    public void shoot()
    {     
            // Play audio when the bullet is fired
            GetComponent<AudioSource>().Play();
            // Instantiate the bullet prefab
            GameObject bullet = (GameObject)Instantiate(PlayerBullet);
            // Set the bullets position when fired
            bullet.transform.position = BulletPosition.transform.position;
    }
    //The move player function
    //Adapted From https://www.youtube.com/watch?v=Om00FwLg-eg&list=PLRN2Qvxmju0Mf1GB1hXsT-x1GQJQ0pwE0&index=2
    private void Move(Vector2 direction)
    {
        // limit the player movement to the screen width and height
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        //Offset to allow for the width of the ship sprite to left of screen
        max.x = max.x - 1f;
        //Offset to allow for the width of the ship sprite to right of screen
        min.x = min.x + 1f;
        // Stop the ship moving all the way to the top as per design document
        max.y = max.y - 3.5f;
        // Offset to allow for the height of the sprite at the bottom of the screen
        min.y = min.y + 1f;
        // Set the position of the player sprite
        Vector2 position = transform.position;
        // The movement transition
        position += direction * speed * Time.deltaTime;
        // Set the boundry of the screen settings so the ship can't move past them
        position.x = Mathf.Clamp(position.x, min.x, max.x);
        position.y = Mathf.Clamp(position.y, min.y, max.y);
        // Update the ship position
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Condition for collisions with either an enemy ship or enemy bullet
        // Using the tag identifier to get access to the game objects
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag") || (col.tag == "BossTag"))
        {
            //Remove the game object if the collision has been detected
            Destroy(gameObject);
           // gameObject.SetActive(false);
            // Decrement the player lives value from the Lives script
            Lives.livesValue--;
           

            //Function to reload the scene used in the game over condition
            // SceneManager.LoadScene(0);
            //Gameover condition
            if (Lives.livesValue == 0)
            {
                //Function to reload the scene used in the game over condition
               
                SceneManager.LoadScene(3);
               
               

            }

        }
        

    }
    


}
