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
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"),0);
        transform.position += move * speed * Time.deltaTime;

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
