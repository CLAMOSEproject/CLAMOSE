using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
    //基本的な情報
    private int batteryRate;
    private int buttoninputCount;
   

    //チャージ倍率
    public int chargeMagnification;

    //バッテリーの減算量
    private float timebySubtractbattery;
    //何もボタン押していないバッテリーの減算率
    public float  keyupbatteryRate;

    //オーバーチャージ中

    //ボタン関連
    private int overchargeButtondownCount;      //ボタンが押されている
    public  int overchargeButtondownMax;        //ボタンのリミット回数
    //左用のボタン
    private int[] leftbuttoninput = new int[4];
    private int leftbuttoninputTotal;

    //勝利判定までの関連

    private float toWinmaintenanceTime;           //勝利するまでに維持する時間
    public short toWinmaintenancetimeLimit;      //勝利するまでの判定時間

    //その他
    private User               user;
    private OverCharge         overCharge;
    public  B_GameStart        gameStart;
    public  GameJudge          isGamePlaynow;
    public  Controller_Input   padController;
    private bool               systemCommandGamejudge;

    // Use this for initialization
    void Start()
    {
        //バッテリーの基本情報
        this.batteryRate = 0;
       
        //ボタンの入力情報
        this.buttoninputCount = 0;
        this.timebySubtractbattery = 0;

       
        //時間関係
        this.overchargeButtondownCount = 0;
        this.toWinmaintenanceTime = 0;

        //その他
        this.user = GetComponent<User>();
        this.overCharge = GetComponent<OverCharge>();

        if(this.gameStart == null)
        {
            Debug.Log("中身無いよー");
        }
        if(this.isGamePlaynow == null)
        {
            Debug.Log("審判なしでゲームを開始しないで");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームスタートと表示されていない　
        if(this.gameStart.isDrawing())
        {
            return;
        }
        //ゲームの勝敗がついた
        if (!this.isGamePlaynow.isGamePlaynow())
        {
            if(this.user.getWinorLos() == User.WinorLos.Non || this.overCharge.getStateName() == "OverCharge")
            { 
                this.user.setMatchDecision(User.WinorLos.Los);
            }
            return;
        }

        

        //勝利判定
        if (this.ChargeMax())
        {
            this.toWinmaintenanceTime += Time.deltaTime;
            if(this.isToWin())
            {
                //勝利のリザルトへ進む
                this.user.setMatchDecision(User.WinorLos.Win);

                //ゲームシステムに勝負結果を報告している
                if(this.systemCommandGamejudge)
                {
                    return;
                }
                if(this.user.getPlayer() == User.Player.Player1)
                {
                    this.systemCommandGamejudge = true;
                    CommonData.AddWinCount(CommonData.CommonState.Player1);
                }
                else if(this.user.getPlayer() == User.Player.Player2)
                {
                    this.systemCommandGamejudge = true;
                    CommonData.AddWinCount(CommonData.CommonState.Player2);
                }
            }
            Debug.Log("勝負判定" + this.toWinmaintenanceTime);
        }

        //バッテリー率の減算
        if (this.timebySubtractbattery >= 1.0f)
        {
            this.timebySubtractbattery = 0;
            this.buttoninputCount -= Random.Range(1, 5);
            //バッテリーが充電量が負になる場合
            if (this.buttoninputCount < 0)
            {
                this.buttoninputCount = 0;
            }
        }
        else
        {
            this.timebySubtractbattery += Time.deltaTime;
        }

        switch (this.overCharge.getStateName())
        {
            case "Normal":
                //ボタンの入力判定
                {
                    if (this.padController.Buttons_Check())
                    {
                        this.buttoninputCount += this.chargeMagnification;
                    }
                }

                break;
            case "Adjustment":
                if(this.padController.Buttons_Check())
                {
                    this.buttoninputCount += this.chargeMagnification;
                    this.overCharge.AdjastmentButtonCountIncrease(1);
                }
                break;
            case "OverChargeCount":
                if(this.overchargeButtondownCount <= this.overchargeButtondownMax)
                {
                    if(this.padController.Buttons_Check())
                    {
                        this.overchargeButtondownCount++;
                    }
                }
                //充電機能
                Debug.Log("オーバーチャージに近づいている" + this.overchargeButtondownCount + "回加算されている");
                break;
            case "OverCharge":
                this.user.setMatchDecision(User.WinorLos.Los);
                break;
        }

        //チャージカウンタを%変換
        this.CountfromRate();
    }

    //バッテリーの充電を行います
    void BatteryChargeCount()
    {
        this.buttoninputCount = this.CheckButtonInputCount();
    }

    //ボタン判定でカウントを増やします
    int  CheckButtonInputCount()
    {
        string[] playerName = new string[2];
        playerName[0] = "PL";
        playerName[1] = "PR";

        int buttonInputCount = 0;
        for (int i = 0; i < 4; ++i)
        {
            buttonInputCount += this.padController.Get_Masshed_Button_One(playerName[(short)this.user.getPlayer()], i);
        }
        return buttonInputCount;
    }

    int OverChargeDecrement()
    {
        return (int)(5 * this.chargeMagnification * 0.8f);
    }

    bool ChargeMax()
    {
        return this.batteryRate == 100;
    }

    public int getbatteryRate()
    {
        return this.batteryRate;
    }

    public string WinnerPlayer()
    {
        return this.gameObject.name;
    }

    void CountfromRate()
    {
        this.batteryRate = this.buttoninputCount;
    }

    //オーバーチャージ中
    public bool isLimitButtonCheck()
    {
        return this.overchargeButtondownCount >= this.overchargeButtondownMax;
    }

    bool isOverCharge()
    {
        return this.overCharge.Check();
    }

    //勝利判定関連
    bool isToWin()
    {
        return this.toWinmaintenanceTime >= this.toWinmaintenancetimeLimit;
    }

    //どちらのゲームパッド操作にするのかを判定します
    string CheckUseGamePadbutton(User.Player player)
    {
        switch(player)
        {
            case User.Player.Player1:
                return "PL";
            case User.Player.Player2:
                return "PR";
        }
        return null;
    }
    bool CheckLeftPlayerButtonInput()
    {
        if (this.user.getPlayer() != User.Player.Player1)
        {
            return false;
        }

        if(this.padController.Head_Switch_Down(0))
        {
            return true;
        }
        if(this.padController.Head_Switch_Down(1))
        {
            return true;
        }
        if(this.padController.Head_Switch_Down(2))
        {
            return true;
        }
        if(this.padController.Head_Switch_Down(3))
        {
            return true;
        }
        return false;
    }
}
