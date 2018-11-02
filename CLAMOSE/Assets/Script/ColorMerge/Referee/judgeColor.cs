using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgeColor : MonoBehaviour {

    public enum WinState
    {
        Non,
        Player1,
        Player2,
    }

    //public:
    public GameObject monita;
    public GameObject player1;
    public GameObject player2;
    public WinState winState;
    public GameObject correctPrefab;

    //private:
    Vector3 monitaColor;
    Vector3 player1Color;
    Vector3 player2Color;
    bool startCheck = true;
    int player1WinCount = 0;
    int player2WinCount = 0;
	// Use this for initialization
	void Start () {
        winState = WinState.Non;
	}
	
	// Update is called once per frame
	void Update () {
        if (!startCheck) { return; }
        //色情報を取得
        ReceiveColor();
        if(winState != WinState.Non) { return; }
        //常に比較します
        if (player1Color == monitaColor)
        {
            ++player1WinCount;
            winState = WinState.Player1;
            EndJudge();
            Debug.Log("プレイヤー1の勝利");
            Instantiate(correctPrefab, new Vector3(3.4f, -2.6f, 0), Quaternion.identity);
        }
        else if(player2Color == monitaColor)
        {
            ++player2WinCount;
            winState = WinState.Player2;
            EndJudge();
            Debug.Log("プレイヤー2の勝利");
            Instantiate(correctPrefab, new Vector3(-3.6f, -2.4f, 0), Quaternion.identity);
        }
	}

    //色を取得します
    void ReceiveColor()
    {
        monitaColor = monita.GetComponent<MonitaSysmtem>().GetColorData();
        Vector3 tmp;
        tmp.y = monitaColor.y;
        monitaColor.y = monitaColor.z;
        monitaColor.z = tmp.y;
        player1Color = player1.GetComponent<playerColor>().GetColorData();
        player2Color = player2.GetComponent<playerColor>().GetColorData();
    }
    //勝敗を返します
    public WinState GetWinState()
    {
        return winState;
    }

    //勝敗をリセットします
    public void ResetState()
    {
        winState = WinState.Non;
        startCheck = false;
    }

    //勝敗判定を開始します
    public void StartJudge()
    {
        startCheck = true;
    }

    //勝敗判定を終了します
    public void EndJudge()
    {
        startCheck = false;
    }

    //プレイヤー1の勝ちカウントの取得
    public int GetPlayer1WinCount()
    {
        return player1WinCount;
    }
    //プレイヤー2の勝ちカウントの取得
    public int GetPlayer2WinCount()
    {
        return player2WinCount;
    }
}
