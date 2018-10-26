using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
    //基本的な情報
    private int batteryRate;
    private int buttoninputCount;
    private bool winFlag;
   

    //チャージ倍率
    public int chargeMagnification;

    //バッテリーの減算量
    private float keyUpCount;
    //何もボタン押していないバッテリーの減算率
    public float keyupbatteryRate;

    //オーバーチャージ中

    //ボタン関連
    private float nonbuttoninputCount;            //ボタンが押されていない
    private int overchargeButtondownCount;      //ボタンが押されている
    public int overchargeButtondownMax;        //ボタンのリミット回数

    //勝利判定までの関連

    private float toWinmaintenanceTime;           //勝利するまでに維持する時間
    public short toWinmaintenancetimeLimit;      //勝利するまでの判定時間

    //その他
    private User        user;
    private OverCharge  overCharge;
    public  B_GameStart gameStart;
    public  GameJudge   isGamePlaynow;


    // Use this for initialization
    void Start()
    {
        //バッテリーの基本情報
        this.batteryRate = 0;
       
        //ボタンの入力情報
        this.buttoninputCount = 0;
        this.keyUpCount = 0;
        this.nonbuttoninputCount = 0;
       
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
            this.user.ToResult(User.WinorLos.Los);
            return;
        }

        //バッテリーが充電量が負になる場合
        if(this.batteryRate < 0)
        {
            this.batteryRate = 0;
        }

        //勝利判定
        if (this.ChargeMax())
        {
            this.toWinmaintenanceTime += Time.deltaTime;
            if(this.isToWin())
            {
                //勝利のリザルトへ進む
                this.user.ToResult(User.WinorLos.Win);
                return;
            }
            Debug.Log("勝負判定" + this.toWinmaintenanceTime);
        }

        //バッテリー率の減算
        if (this.keyUpCount >= 1.0f)
        {
            this.buttoninputCount -= (int)this.keyUpCount * 2;
            this.keyUpCount = 0;
        }


        switch (this.overCharge.getStateName())
        {
            case "Normal":
                if (this.ButtonInputCheck())
                {
                    this.buttoninputCount += this.ButtonInputCount();
                }

                //キーボード操作が離れているとき
                if (this.KeyUP())
                {
                    this.keyUpCount += Time.deltaTime + 0.1f;
                }
                break;
            case "Adjustment":
                if (this.KeyUP())
                {
                    //調整中のボタン判定回数にも増加させる
                    this.overCharge.AdjastmentButtonCountIncrease(this.ButtonInputCount());
                    this.keyUpCount += Time.deltaTime + 0.3f;
                }
                break;
            case "OverChargeCount":
                //充電機能
                if (this.ButtonInputCheck())
                {
                    this.buttoninputCount += this.ButtonInputCount();
                    this.overchargeButtondownCount += 1;
                    Debug.Log("オーバーチャージ中に" + this.overchargeButtondownCount + "回加算されている");
                }
                //キーボード離れたときのカウンタ
                else
                {
                    this.nonbuttoninputCount += Time.deltaTime;
                }
                if (this.nonbuttoninputCount >= 4.0f)
                {
                    this.buttoninputCount -= this.OverChargeDecrement();
                    this.nonbuttoninputCount = 0;
                    Debug.Log("チャージ率を減算します" + this.batteryRate + "%");
                }
                break;
            case "OverCharge":
                break;
        }

        //チャージカウンタを%変換
        this.CountfromRate();
        Debug.Log(this.batteryRate + "％");
    }

    //ボタンの判定
    bool ButtonInputCheck()
    {
        switch (this.user.getPlayer().ToString())
        {
            case "Player1":
                return Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D);
            case "Player2":
                return Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.J);
        }
        return false;
    }

    int ButtonInputCount()
    {
        return 1 * this.chargeMagnification;
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



    bool KeyUP()
    {
        bool keyupFlag = false;
        switch (this.user.getPlayer().ToString())
        {
            case "Player1":
                keyupFlag = Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D);
                break;
            case "Player2":
                keyupFlag = Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.L);
                break;
        }
        return keyupFlag;
    }

    public float getNonbuttoninputCount()
    {
        return this.nonbuttoninputCount;
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
}
