using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheack : MonoBehaviour
{
    //チェックするプレイヤ
    public GameObject PL, PR;
    //各プレイヤ側の勝ちアニメーションを再生するプレハブ
    //現在作られていない
    public GameObject winner_L_Small, winner_L_Big, winner_R_Small, winner_R_Big;
    //判定を修得するオブジェクト
    Collisioin_Checker checker;
    //小さい魚がどっちかを確認する変数
    string who_Is_Small;

	// Use this for initialization
	void Start ()
    {
        //コリジョンチェッカ修得
        if (PL.transform.parent.GetComponent<Collisioin_Checker>() == null)
        {
            //小さい魚が右
            checker = PR.transform.parent.GetComponent<Collisioin_Checker>();
            who_Is_Small = "PR";
        }
        else
        {
            //小さい魚が左
            checker = PL.transform.parent.GetComponent<Collisioin_Checker>();
            who_Is_Small = "PL";
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		//どっちが勝ったのかを判定
        if(checker.Is_Eated())
        {
            //右プレイヤの勝ち
            //アニメーション用プレハブ生成
            //Instantiate(winner_R, PR.transform.position,Quaternion.identity);
            Debug.Log("big win");

            //プレイヤと判定オブジェクトもアクティブfalseにする
            PR.transform.parent.gameObject.SetActive(false);
            PL.transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if(checker.Is_Alived())
        {
            //左プレイヤの勝ち
            //アニメーション用プレハブ生成
            //Instantiate(winner_L, PL.transform.position,Quaternion.identity);
            Debug.Log("small win");

            //プレイヤと判定オブジェクトもアクティブfalseにする            
            PL.transform.parent.gameObject.SetActive(false);
            PR.transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
	}
}
