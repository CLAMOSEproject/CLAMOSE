using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Control : MonoBehaviour
{
    //勝った時のサウンド
    public GameObject win_Sound;

    //結果シーンまでの時間
    const int tick_To_Next_Scene = 300;
    //タイムカウント
    int time_Count;

	// Use this for initialization
	void Start ()
    {
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
            //現在処理なし
        }

        //カウント上昇
        time_Count++;
	}
}
