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

    //勝利者を出力
    public void SetWinorLos()
    {
        if(this.winorLos < WinorLos.Los)
        {
            return;
        }

        switch(this.winorLos)
        {
            case WinorLos.Win:
                Debug.Log("勝ったね " + this.gameObject.name + "  " + this.winorLos.ToString());
                break;
            case WinorLos.Los:
                Debug.Log("負けたね " + this.gameObject.name + "  " + this.winorLos.ToString());
                break;
            case WinorLos.Draw:
                break;
            default:
                Debug.Log("勝敗判定がおかしい");
                break;
        }
    }

    public void ToResult(WinorLos winorLos)
    {
        this.setMatchDecision(winorLos);
        this.SetWinorLos();
    }

    public void setMatchDecision(WinorLos winorLos)
    {
        this.winorLos = winorLos;
    }
}
