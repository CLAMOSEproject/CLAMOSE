using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameJudge : MonoBehaviour
{

    //戦っている相手の情報
    public User playerLeft;
    public User playerRight;


    //ゲーム勝利結果のデータ取得
    private User.WinorLos matchDecisionplayerLeft;
    private User.WinorLos matchDecisionplayerRight;

    //ゲームが終了した後の処理
    private B_Result      gameResult;
    private bool gameflag = false;


    // Use this for initialization
    void Start()
    {
        if (this.playerLeft == null || this.playerRight == null)
        {
            Debug.Log("Player設置してないよお");
            Application.Quit();
        }
        this.gameResult = GetComponent<B_Result>();
    }

    // Update is called once per frame
    void Update()
    {
        this.ResultStateUpDate();
        if (!this.isGamePlaynow())
        {
            //どちらのPlayerの勝利結果が欲しいかを判定
            if (this.gameResult.name.Substring(6, 4) == "Left")
            {
                Debug.Log("OKL");
                this.gameResult.ToResult(this.matchDecisionplayerLeft);
            }
            else if(this.gameResult.name.Substring(6, 5) == "Right")
            {
                Debug.Log("OKR");
                this.gameResult.ToResult(this.matchDecisionplayerRight);
            }
            if(!gameflag)
            {
                if(matchDecisionplayerLeft == User.WinorLos.Win)
                {
                    CommonData.AddWinCount( CommonData.CommonState.Player2);
                }
                else
                {
                    CommonData.AddWinCount(CommonData.CommonState.Player1); 
                }
                gameflag = true;
            }
        }
    }

    public bool isGamePlaynow()
    {
        return this.matchDecisionplayerLeft == User.WinorLos.Non && this.matchDecisionplayerRight == User.WinorLos.Non;
    }

    void ResultStateUpDate()
    {
        this.matchDecisionplayerLeft  = this.playerLeft.getWinorLos();
        this.matchDecisionplayerRight = this.playerRight.getWinorLos();

        if(this.matchDecisionplayerLeft == User.WinorLos.Los)
        {
            this.matchDecisionplayerRight = User.WinorLos.Win;
            
        }
        else if(this.matchDecisionplayerRight == User.WinorLos.Los)
        {
            this.matchDecisionplayerLeft = User.WinorLos.Win;
           
        }
    }
}
