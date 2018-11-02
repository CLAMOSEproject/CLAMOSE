using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectSound : MonoBehaviour {

    public AudioSource correct;
	// Use this for initialization
	void Start () {
        correct = GetComponent<AudioSource>();
        correct.PlayOneShot(correct.clip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
