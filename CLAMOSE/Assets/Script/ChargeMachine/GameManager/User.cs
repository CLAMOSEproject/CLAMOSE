using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {

    public enum Player
    {
        Player1 = 0,
        Player2 = 1,
    }

    public Player player;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Player getPlayer()
    {
        return this.player;
    }
}
