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

    private enum WinorLos
    {
        Non  = 0,
        Draw = 1,
        Win  = 2,
        Los  = 4
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

    public void SetWinorLos(short winorLos)
    {
        if(winorLos < 0)
        {
            return;
        }
        this.winorLos = (WinorLos)winorLos;
        Debug.Log(this.gameObject.name + "  " + this.winorLos.ToString());
    }
}
