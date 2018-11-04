using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    Vector2 scale;
	// Use this for initialization
	void Start () {
        scale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        scale.x = BossController.health;
        transform.localScale = scale;
	}
}
