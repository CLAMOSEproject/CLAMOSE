using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWinPointSound : MonoBehaviour {

    public AudioSource win;
    public AudioSource cheer;
	// Use this for initialization
	void Start () {
        AudioSource[] sources = GetComponents<AudioSource>();
        win = sources[0];
        win.PlayOneShot(win.clip);
        cheer = sources[1];
        cheer.PlayOneShot(cheer.clip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
