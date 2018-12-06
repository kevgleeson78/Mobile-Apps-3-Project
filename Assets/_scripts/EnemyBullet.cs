/* Application Name: Space Attack
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: A script to set the direction of teh bullet taken from the enemyGun Script.
 * The speed of the bullets are also increased once teh boss character has been defeated.
 * Collision detection is here for player ships and bullets.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapted from https://www.youtube.com/watch?v=2WlY0dL5Qrg&list=PLRN2Qvxmju0Mf1GB1hXsT-x1GQJQ0pwE0&index=3
public class EnemyBullet : MonoBehaviour {
    //Bullet speed
    float speed;
    //Bullet direction
    Vector2 _direction;
    // Firing ready
    bool isReady;
    // Use this for initialization
    private void Awake()
    {
        //Increase teh speed of the bullets once the boss has been defeted
        speed = 2.5f + BossController.difficluty;
        isReady = false;
    }
    void Start () {
		
	}
	public void setDirection(Vector2 direction)
    {
        //Set the direction of the bullets
        _direction = direction.normalized;
        isReady = true;
    }
	// Update is called once per frame
	void Update () {
        if (isReady)
        {
            //Animation of teh bullets
            Vector2 position = transform.position;
            //upodateing the bullets position
            position += _direction * speed * Time.deltaTime;
            //Transform the animation
            transform.position = position;
            //The max distance the bullets can travell
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            //Destroy the bullets once they have left the screen
            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Destroy the bullets if the player ship or bullet has collided with the enemy bullet.
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            Destroy(gameObject);
            
        }
    }
}
