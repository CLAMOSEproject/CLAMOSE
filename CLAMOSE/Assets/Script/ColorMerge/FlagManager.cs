using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour {

    public Dictionary<string, object> flagDictionary =
        new Dictionary<string, object>();

    int player1Win = 0;
    int player2Win = 0;
    int gameCnt = 0;
    public int MaxGameNum = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameCnt >= MaxGameNum)
        {
            if(player1Win > player2Win)
            {
                //プレイヤー1の勝利
            }
            else if(player1Win < player2Win)
            {
                //プレイヤー2の勝利
            }
            else
            {
                //引き分け
            }
        }
	}
    public void Player1AddWin()
    {
        player1Win += 1;
        gameCnt += 1;
    }
    public void Player2AddWin()
    {
        player2Win += 1;
        gameCnt += 1;
    }
}
