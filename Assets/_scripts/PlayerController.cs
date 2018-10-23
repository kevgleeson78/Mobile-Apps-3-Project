using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    //Get acces to the player bullet prefab
    public GameObject PlayerBullet;
    // For positioning of the bullet at the top of the spaceship
    public GameObject BulletPosition;
    // The speed the ship travels
    
    public float speed = 1;
    // Use this for initialization
   
       
    
    
    // Update is called once per frame
    void Update () {
        // x,y for getting the verticle and horizontal movements of the ship
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxis("Vertical");
        // TO set the direction of the ship
        Vector2 direction = new Vector2(x, y).normalized;
        // Call the move function
        Move(direction);
        // Input for fire of bullet
        if (Input.GetKeyDown("space"))
        {
            // Play audio when the bullet is fired
            GetComponent<AudioSource>().Play();
            // Instantiate the bullet prefab
            GameObject bullet = (GameObject)Instantiate(PlayerBullet);
            // Set the bullets position when fired
            bullet.transform.position = BulletPosition.transform.position;
        }

       
       
    }

    private void Move(Vector2 direction)
    {
        // limit the player movement to the screen width and height
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        //Offset to allow for the width of the ship sprite to left of screen
        max.x = max.x - 1.5f;
        //Offset to allow for the width of the ship sprite to right of screen
        min.x = min.x + 1.5f;
        // Stop the ship moving all the way to the top as per design document
        max.y = max.y - 3.5f;
        // Offset to allow for the height of the sprite at the bottom of the screen
        min.y = min.y + 1.5f;
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
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            //Remove the game object if the collision has been detected
            Destroy(gameObject);
            
            // Decrement the player lives value from the Lives script
            Lives.livesValue--;

            //Function to reload the scene used in the game over condition
            // SceneManager.LoadScene(0);
           

        }
        
        //Gameover condition
        if (Lives.livesValue == 0)
        {
            //Function to reload the scene used in the game over condition
            SceneManager.LoadScene(0);
            //Set the initial value of lives to three
            Lives.livesValue = 3;
            //Set the initial score value to zero for the start of the game
            Score.scoreValue = 0;
        }
    }

   
}
