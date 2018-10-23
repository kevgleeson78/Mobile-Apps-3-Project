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
