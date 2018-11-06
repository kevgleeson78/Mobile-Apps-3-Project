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
using UnityEngine.UI;

public class Lives : MonoBehaviour {
    public static int livesValue = 3;
    Text lives;
    // Use this for initialization
    void Start () {
       
        lives = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        lives.text = "Lives: " + livesValue;
    }
}
