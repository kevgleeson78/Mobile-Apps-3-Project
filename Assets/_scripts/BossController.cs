

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //Var to hold enemy speed
    float speed;
    // Use this for initialization
    void Start()
    {   //Set speed
        speed = 1f;
    }

    private bool dirRight = true;


    void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
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
    }
        private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBulletTag")
        {
            Destroy(gameObject);
            Score.scoreValue = Score.scoreValue + 10;
        }
        if (col.tag == "PlayerShipTag")
        {
            Destroy(gameObject);
        }
    }

}
