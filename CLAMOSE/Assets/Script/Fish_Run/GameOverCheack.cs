using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheack : MonoBehaviour
{
    //チェックするプレイヤ
    public GameObject PL, PR;
    //各プレイヤ側の勝ちアニメーションを再生するプレハブ
    //現在作られていない
    public GameObject winner_L, winner_R;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		//どっちが勝ったのかを判定
        if(PL.active == false)
        {
            //右プレイヤの勝ち
            //アニメーション用プレハブ生成
            //Instantiate(winner_R, PR.transform.position,Quaternion.identity);
            Debug.Log("right win");

            //勝ち抜いたプレイヤと判定オブジェクトもアクティブfalseにする
            PR.transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if(PR.active == false)
        {
            //左プレイヤの勝ち
            //アニメーション用プレハブ生成
            //Instantiate(winner_L, PL.transform.position,Quaternion.identity);
            Debug.Log("left win");

            //勝ち抜いたプレイヤと判定オブジェクトもアクティブfalseにする            
            PL.transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
	}
}
