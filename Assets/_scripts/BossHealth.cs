/* Application Name: Space Attack
 * File Name : BossHealth
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: 
 * This script is used to scale a sprite image that is a child of the boss game object.
 * When a collision is detected teh bossController script decrements it health value.
 * The local scale.x is the scaled with the update function.
 * It will scale down in size as the bosss character gets hit with a player bullet.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapted from: https://www.youtube.com/watch?v=yeMOuXiVAos
public class BossHealth : MonoBehaviour {
    // A vector2 variable to hold and be able to scale the boss sprtie image.
    Vector2 scale;
	// Use this for initialization
	void Start () {
        //set the scale object to be able to scale up and down
        scale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        // Scale the boss health meter along the x axis acording to the boss health value
        // In the bossController.cs script.
        scale.x = BossController.health;
        //Sale the sprite from new value if any.
        transform.localScale = scale;
	}
}
