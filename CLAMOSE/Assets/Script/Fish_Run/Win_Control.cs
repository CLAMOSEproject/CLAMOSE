using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Control : MonoBehaviour
{
    //勝った時のサウンド
    public GameObject win_Sound;

    //結果シーンまでの時間
    const int tick_To_Next_Scene = 300;
    //タイムカウント
    int time_Count;

    //勝ち側のプレイヤ
    int winner;

    //勝ち側セット
    public void Set_Winner_Fish_Run(int pl)
    {
        winner = pl;
    }

	// Use this for initialization
	void Start ()
    {
        winner = -1;
        //音源再生
        Instantiate(win_Sound).transform.SetParent(this.transform);

        //時間初期化        
        time_Count = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		//次のシーンを呼ぶ
        if(time_Count > tick_To_Next_Scene)
        {
            //勝利者登録
            CommonData.AddWinCount((CommonData.CommonState)winner);
            //次のシーンを呼ぶ
            SceneManager.LoadScene("Result");
        }

        //カウント上昇
        time_Count++;
	}
}
