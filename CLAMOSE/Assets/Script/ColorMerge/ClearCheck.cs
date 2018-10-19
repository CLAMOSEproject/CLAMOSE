using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck : MonoBehaviour {

    private playerColor playerColor;
    private colorSelect themeColor;
    //private FlagManager flagManager;
    public string playerName;
	// Use this for initialization
	void Start () {
        playerColor = GetComponent<playerColor>();
        themeColor = GetComponent<colorSelect>();
        //flagManager = GetComponent<FlagManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerColor == themeColor)
        {
            switch(playerName)
            {
                case "player1":
                    //flagManager.Player1AddWin();
                    break;
                case "player2":
                    //flagManager.Player2AddWin();
                    break;
            }
        }
	}
}
