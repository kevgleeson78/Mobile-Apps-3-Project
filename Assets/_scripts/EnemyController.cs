

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Var to hold enemy speed
    float speed;
    // Use this for initialization
    void Start()
    {   //Set speed
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
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
        if ((col.tag == "PlayerShipTag")||(col.tag == "PlayerBulletTag"))
        {
            Destroy(gameObject);
            Score.scoreValue = Score.scoreValue + 10;
        }
    }

}
