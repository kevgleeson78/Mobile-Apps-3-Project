

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapted from https://forum.unity.com/threads/left-and-right-enemy-moving-in-2d-platformer.364716/
public class BossController : MonoBehaviour
{
    //Var to hold enemy speed
    float speed;
    private bool dirRight = true;
   
    // Use this for initialization
    public static float health;
    void Start()
    {   //Set speed
        speed = 2f;
        health = 10;
    }

    


    void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - 4f;
        //Offset to allow for the width of the ship sprite to right of screen
        min.x = min.x + 4f;
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= max.x)
        {
            dirRight = false;
        }

        if (transform.position.x <= min.x)
        {
            dirRight = true;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
        private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBulletTag")
        {
            health -= .1f;
            Score.scoreValue = Score.scoreValue + 10;
        }
        if (col.tag == "PlayerShipTag")
        {
            health -= .1f;
        }
    }

}
