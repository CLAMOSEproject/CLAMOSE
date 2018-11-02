using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPenSound : MonoBehaviour {

    public AudioSource sound;

    //private:
    TimeCnt time;
	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
        time = GetComponent<TimeCnt>();
	}
	
	// Update is called once per frame
	void Update () {
        if(time.GetFrameCount() == 1.0f)
        {
            sound.PlayOneShot(sound.clip);
        }
	}
}
