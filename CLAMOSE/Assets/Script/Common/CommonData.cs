using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonData {

    //ステート情報
    public enum CommonState
    {
        Non = -1,
        Player1 = 0,
        Player2 = 1,
        Draw = 4,
    };

    
    //シーン間の共通データ
    static int[] winCount = new int[3];
    static CommonState[] winState = new CommonState[3];
    static int gameCount = -1;

    // Use this for initialization
    void Start()
    {
        for(int i = 0;i < 3;++i)
        {
            winCount[i] = 0;
            winState[i] = CommonState.Non;
        }
        gameCount = -1;
    }

    //ゲーム全体の勝ちカウントを1プラスする
    //
    public static void AddWinCount(CommonState playerState)
    {
        int cnt = 0;
        switch(playerState)
        {
            case CommonState.Player1: cnt = 0; break;
            case CommonState.Player2: cnt = 1; break;
            case CommonState.Draw:  cnt = 2; break;
        }
        ++winCount[cnt];
        ++gameCount;
        winState[gameCount] = playerState;
    }
    //ゲーム全体の勝ちカウントの取得
    public static int GetWinCount(CommonState playerState)
    {
        return winCount[(int)playerState];
    }
    //指定したステートが勝ったかを返す
    //何番目のゲームで、どちらが勝利したかを指定する
    public static bool GetWinState(CommonState playerState)
    {
        return winState[gameCount] == playerState;
    }
    //指定した番号のゲームで、勝利したステートを返す
    public static CommonState GetCommonState(int gameCnt)
    {
        return winState[gameCnt];
    }
    //指定した番号のゲームで、そのステートが勝ちかを返す
    public static bool CheckWinState(CommonState playerState,int gameCnt)
    {
        if(GetCommonState(gameCnt) == playerState)
        {
            return true;
        }
        return false;
    }
    //現在のおこなったゲームの回数を取得します
    public static int GetNowGameCnt()
    {
        if(gameCount < 0)
        {
            return 0;
        }
        return gameCount;
    }
}
