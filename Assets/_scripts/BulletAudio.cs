using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAudio : MonoBehaviour {
    [SerializeField]
    private AudioClip shootSound;

    private AudioSource source;
    // Use this for initialization
    void Start () {
        
	}
    void Awake()
    {

        source = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.PlayOneShot(shootSound);
        }
	}
}
