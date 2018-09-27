using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public float speed = 1;
    // Update is called once per frame
    void Update () {
        float h = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(h, 0) * speed;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name
        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.name == "Enemy(Clone)")
        {
            Destroy(gameObject);

        }
        
    }
}
