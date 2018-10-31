using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll_Last_Result : MonoBehaviour
{
    //どっちが勝ったかを保存する場所
    int[] who_Is_Win;
    //全体スコア
    int all_Score;

    //表示するスプライト
    public GameObject round1, round2, round3,last;

	// Use this for initialization
	void Start ()
    {
        //フラグ初期化
        who_Is_Win = new int[Game_Selector.max_Games] { -1,-1,-1 };

        //commonデータからもらってくる
        //今は仮処理
        for(int i =0; i<Game_Selector.max_Games; i++)
        {
            who_Is_Win[i] = 1;
        }

        //全体スコア計算
        all_Score = 0;
        for (int s =0; s<3; s++)
        {
            all_Score += who_Is_Win[s];
        }

        //送る
        for (int r = 1; r <= 4; r++)
        {
            Transport_To_Object(r);
        }
	}

    //オブジェクトに勝ち負けを転送するメソッド
    void Transport_To_Object(int round)
    {
        switch(round)
        {
            case 1:
                //転送
                round1.GetComponent<Controll_Score_Board>().Set_Winner(who_Is_Win[round-1]);
                break;
            case 2:
                //転送
                round2.GetComponent<Controll_Score_Board>().Set_Winner(who_Is_Win[round-1]);
                break;
            case 3:
                //転送
                round3.GetComponent<Controll_Score_Board>().Set_Winner(who_Is_Win[round-1]);
                break;
            case 4:
                last.GetComponent<Controll_Score_Board>().Set_Winner(all_Score);
                break;
            
            default:
                break;
        }
    }

	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
