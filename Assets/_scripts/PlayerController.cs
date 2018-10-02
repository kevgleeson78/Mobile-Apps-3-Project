using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject bullet;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0f;
    // Use this for initialization
    void Start () {
  
    }
    public float speed = 1;
    // Update is called once per frame
    void Update () {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"),0);
        transform.position += move * speed * Time.deltaTime;
        if(Input.GetButtonDown("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
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
    void fire()
    {
        bulletPos = transform.position;
        bulletPos += new Vector2(+1f, -0.43f);
        Instantiate(bullet, bulletPos, Quaternion.identity);
      
    }
}
