using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCongSound : MonoBehaviour {

    public AudioSource cong;
	// Use this for initialization
	void Start () {
        cong = GetComponent<AudioSource>();
        cong.PlayOneShot(cong.clip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
