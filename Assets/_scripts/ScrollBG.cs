/* Application Name: Space Attack
 * File Name: 
 * Version: 1.0
 * @Date: 10/10/2018
 * @Author: Kevin Gleeson
 * Desc: 
 * 
 * Refferences:
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapted From https://www.youtube.com/watch?v=HrDxnMI7pCc
public class ScrollBG : MonoBehaviour {
    public float speed;
	
	
	// Update is called once per frame
	void Update () {

        //For continious scrolling of the background stars
        Vector2 offset = new Vector2(0 ,Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
