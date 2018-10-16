using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgeColor : MonoBehaviour {

    public enum WinState
    {
        Non,
        Player1,
        Player2
    }

    //public:
    public GameObject monita;
    public GameObject player1;
    public GameObject player2;
    public WinState winState;

    //private:
    Vector3 monitaColor;
    Vector3 player1Color;
    Vector3 player2Color;
    bool startCheck = true;
	// Use this for initialization
	void Start () {
        winState = WinState.Non;
	}
	
	// Update is called once per frame
	void Update () {
        if (!startCheck) { return; }
        //色情報を取得
        ReceiveColor();
        //常に比較します
        if (player1Color == monitaColor)
        {
            winState = WinState.Player1;
            EndJudge();
            Debug.Log("プレイヤー1の勝利");
        }
        else if(player2Color == monitaColor)
        {
            winState = WinState.Player2;
            EndJudge();
            Debug.Log("プレイヤー2の勝利");
        }
	}

    //色を取得します
    void ReceiveColor()
    {
        monitaColor = monita.GetComponent<MonitaSysmtem>().GetColorData();
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
}
