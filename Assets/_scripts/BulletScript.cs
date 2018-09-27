using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public GameObject bulletPrefab;
    private List<GameObject> Bullet = new List<GameObject>();
    private float bulletVelocity;
	// Use this for initialization
	void Start () {
        bulletVelocity = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet.Add(bullet);
        }
        for (int i = 0; i < Bullet.Count; i++)
        {
            GameObject goBullet = Bullet[i];
            if(goBullet!= null)
            {
                goBullet.transform.Translate(new Vector3(0, 1) * Time.deltaTime  * bulletVelocity);

                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);

                if(bulletScreenPos.y >= Screen.height)
                {
                    Destroy(goBullet);
                    Bullet.Remove(goBullet);
                }
            }
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
}
