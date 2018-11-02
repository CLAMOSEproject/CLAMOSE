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
                this.gameResult.ToResult(this.matchDecisionplayerLeft);
            }
            else if(this.gameResult.name.Substring(6, 5) == "Right")
            {
                this.gameResult.ToResult(this.matchDecisionplayerRight);
            }
            if(!gameflag)
            {
                if(matchDecisionplayerLeft == User.WinorLos.Win)
                {
                    CommonData.AddWinCount( CommonData.CommonState.Player1);
                }
                else
                {
                    CommonData.AddWinCount(CommonData.CommonState.Player2); 
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
        if (this.matchDecisionplayerLeft == User.WinorLos.Non)
        {
            this.matchDecisionplayerLeft = this.playerLeft.getWinorLos();
        }
        if (this.matchDecisionplayerRight == User.WinorLos.Non)
        {
            this.matchDecisionplayerRight = this.playerRight.getWinorLos();
        }
        //右プレイヤーによって決まる
        if (this.matchDecisionplayerLeft == User.WinorLos.Non)
        {
            switch (this.matchDecisionplayerRight)
            {
                case User.WinorLos.Win: this.matchDecisionplayerLeft = User.WinorLos.Los; break;
                case User.WinorLos.Los: this.matchDecisionplayerLeft = User.WinorLos.Win; break;
                case User.WinorLos.Draw: this.matchDecisionplayerLeft = User.WinorLos.Draw; break;
            }
        }
        if (this.matchDecisionplayerRight == User.WinorLos.Non)
        {
            //左プレイヤーによって決まる
            switch (this.matchDecisionplayerLeft)
            {
                case User.WinorLos.Win: this.matchDecisionplayerRight = User.WinorLos.Los; break;
                case User.WinorLos.Los: this.matchDecisionplayerRight = User.WinorLos.Win; break;
                case User.WinorLos.Draw: this.matchDecisionplayerRight = User.WinorLos.Draw; break;
            }
        }
    }
}
