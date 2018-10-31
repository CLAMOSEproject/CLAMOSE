using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonData {

    //ステート情報
    public enum CommonState
    {
        Non = -1,
        Player1,
        Player2,
        Draw,
    };

    //シーン間の共通データ
    //static CommonState commonState;
    static int[] winCount = new int[3];


    // Use this for initialization
    void Start()
    {
        for(int i = 0;i < 3;++i)
        {
            winCount[i] = 0;
        }
    }

    //ゲーム全体の勝ちカウントを1プラスする
    public static void AddWinCount(CommonState playerState)
    {
        ++winCount[(int)playerState];
    }
    //ゲーム全体の勝ちカウントの取得
    public static int GetWinCount(CommonState playerState)
    {
        return winCount[(int)playerState];
    }
}
