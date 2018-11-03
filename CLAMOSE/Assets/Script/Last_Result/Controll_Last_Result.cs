using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controll_Last_Result : MonoBehaviour
{
    //どっちが勝ったかを保存する場所
    int[] who_Is_Win;
    //全体スコア
    int all_Score;
    //制御用タイムカウント
    int time_Count;
    //各項目出現のカウント
    public int tick;

    //表示するスプライト
    public GameObject round1, round2, round3,last;
    public GameObject final_Result_Image;

    //破裂音
    public GameObject crash_Sound;

    void Go_Title()
    {
        SceneManager.LoadScene("Title");
    }

	// Use this for initialization
	void Start ()
    {
        //初期時間
        time_Count = 0;
        //フラグ初期化
        who_Is_Win = new int[Game_Selector.max_Games] { -1,-1,-1 };

        //commonデータからもらってくる
        for(int i =0; i<Game_Selector.max_Games; i++)
        {
            who_Is_Win[i] = (int)CommonData.GetCommonState(i);
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
        switch(all_Score)
        {
            //左勝利
            case 0:
            case 1:
            case 4:
                final_Result_Image.GetComponent<Movie_Scene_Image_Selecter>().Set_Image(0);
                break;
            //右勝利
            case 2:
            case 3:
            case 6:
                final_Result_Image.GetComponent<Movie_Scene_Image_Selecter>().Set_Image(1);
                break;
            //引分け
            case 5:
                final_Result_Image.GetComponent<Movie_Scene_Image_Selecter>().Set_Image(2);
                break;
        }

        //送った後activeをfalseにする
        round1.SetActive(false);
        round2.SetActive(false);
        round3.SetActive(false);
        last.SetActive(false);
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
		//時間に対して処理
        switch(time_Count/tick)
        {
            //各項目表示＆サウンド再生
            case 1:                
                round1.SetActive(true);
                if(time_Count%tick == 0 && time_Count <500)
                {
                    Instantiate(crash_Sound);
                }
                break;
            case 2:
                round2.SetActive(true);
                if (time_Count % tick == 0 && time_Count < 500)
                {
                    Instantiate(crash_Sound);
                }
                //サウンド再生
                break;
            case 3:
                round3.SetActive(true);
                if (time_Count % tick == 0 && time_Count < 500)
                {
                    Instantiate(crash_Sound);
                }
                //サウンド再生
                break;
            case 4:
                last.SetActive(true);
                if (time_Count % tick == 0 && time_Count < 500)
                {
                    Instantiate(crash_Sound);
                }
                //サウンド再生
                break;
            case 5:
                final_Result_Image.GetComponent<Final_Image_Alpha>().Increment_Start();
                round1.GetComponent<Controll_Score_Board>().Decrement_Start();
                round2.GetComponent<Controll_Score_Board>().Decrement_Start();
                round3.GetComponent<Controll_Score_Board>().Decrement_Start();
                last.GetComponent<Controll_Score_Board>().Decrement_Start();
                break;
        }

        //タイトルに戻る
        if(time_Count > 600 || Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            Go_Title();
        }

        //カウント上昇
        time_Count++;
	}
}
