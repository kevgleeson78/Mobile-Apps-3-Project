

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>();
        
        gameObject.AddComponent<Rigidbody2D>().gravityScale = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name
        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.name == "bullet(Clone)")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);

        }
        if (col.gameObject.name == "spaceship")
        {
            Destroy(gameObject);

        }

    }
}
