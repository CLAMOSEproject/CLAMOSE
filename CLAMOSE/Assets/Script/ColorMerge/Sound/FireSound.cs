using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour {

    public AudioSource fire;
	// Use this for initialization
	void Start () {
        fire = GetComponent<AudioSource>();
        fire.PlayOneShot(fire.clip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
