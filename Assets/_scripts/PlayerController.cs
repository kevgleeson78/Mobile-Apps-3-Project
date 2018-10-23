using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public GameObject PlayerBullet;
    public GameObject BulletPosition;
    public float speed = 1;
    // Use this for initialization
    void Start () {
  
    }
    
    // Update is called once per frame
    void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
        if (Input.GetKeyDown("space"))
        {
            GetComponent<AudioSource>().Play();
            GameObject bullet = (GameObject)Instantiate(PlayerBullet);
            bullet.transform.position = BulletPosition.transform.position;
        }

       
       
    }

    private void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - 1.5f;
        min.x = min.x + 1.5f;

        max.y = max.y - 3.5f;
        min.y = min.y + 1.5f;

        Vector2 position = transform.position;

        position += direction * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, min.x, max.x);
        position.y = Mathf.Clamp(position.y, min.y, max.y);

        transform.position = position;



    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
            
            Lives.livesValue--;


        }
        if(Lives.livesValue == 0)
        {
            Lives.livesValue = 3;
            Score.scoreValue = 0;
        }
    }

}
