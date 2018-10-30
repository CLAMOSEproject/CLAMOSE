using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public enum Player
    {
        Player1 = 0,
        Player2 = 1,
    }

    public Player player;

    public enum WinorLos
    {
        Non  = 0,
        Draw = 1,
        Win  = 2,
        Los  = 3
    };

    WinorLos winorLos;
	// Use this for initialization
	void Start ()
    {
        this.winorLos = WinorLos.Non;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Player getPlayer()
    {
        return this.player;
    }



    public string getWinorLosName()
    {
        return this.winorLos.ToString();
    }

    public WinorLos getWinorLos()
    {
        return this.winorLos;
    }

    public void setMatchDecision(WinorLos winorLos)
    {
        this.winorLos = winorLos;
    }
}
