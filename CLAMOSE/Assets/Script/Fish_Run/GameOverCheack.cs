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
    //ゲームが左行きか右行きか判断するフラグ
    bool going_Left_Flag;

    public float zpos;

    //左右を決めるメソッド
    public void Game_Going_Left()
    {
        going_Left_Flag = true;
    }

    void Get_Checker()
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
	// Use this for initialization
	void Start ()
    {
        going_Left_Flag = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //チェッカーがヌルの間ずっと試す
        if(checker == null)
        {
            Get_Checker();
        }
		//どっちが勝ったのかを判定
        //食われた場合
        if(checker.Is_Eated())
        {
            Vector3 winner_Pos = PR.transform.parent.position;            
            winner_Pos.z += zpos;
            //右行き
            if (going_Left_Flag == false)
            {
                winner_Pos.x += 5;
                //アニメーション用プレハブ生成
                Instantiate(winner_R_Big, winner_Pos, Quaternion.identity).GetComponent<Win_Control>().Set_Winner_Fish_Run(0);
            }
            //左行き
            else
            {
                winner_Pos.x -= 5;
                //アニメーション用プレハブ生成
                Instantiate(winner_L_Big, winner_Pos, Quaternion.identity).GetComponent<Win_Control>().Set_Winner_Fish_Run(1);
            }
            Debug.Log("big win");

            //プレイヤと判定オブジェクトもアクティブfalseにする
            PR.transform.parent.gameObject.SetActive(false);
            PL.transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if(checker.Is_Alived())
        {
            Vector3 winner_Pos = PL.transform.parent.position;

            winner_Pos.z += zpos;
            //右行き
            if (going_Left_Flag == false)
            {
                winner_Pos.x += 10;
                //アニメーション用プレハブ生成
                Instantiate(winner_R_Small, winner_Pos, Quaternion.identity).GetComponent<Win_Control>().Set_Winner_Fish_Run(1);
            }
            //左行き
            else
            {
                winner_Pos.x -= 10;
                Instantiate(winner_L_Small, winner_Pos, Quaternion.identity).GetComponent<Win_Control>().Set_Winner_Fish_Run(0);
            }
            Debug.Log("small win");

            //プレイヤと判定オブジェクトもアクティブfalseにする            
            PL.transform.parent.gameObject.SetActive(false);
            PR.transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
	}
}
