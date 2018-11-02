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
    private float keyUpCount;
    //何もボタン押していないバッテリーの減算率
    public float keyupbatteryRate;
    //オーバーチャージ中
    //ボタン関連
    private float nonbuttoninputCount;            //ボタンが押されていない
    private int overchargeButtondownCount;      //ボタンが押されている
    public  int overchargeButtondownMax;        //ボタンのリミット回数
    //勝利判定までの関連
    private float toWinmaintenanceTime;           //勝利するまでに維持する時間
    public short toWinmaintenancetimeLimit;      //勝利するまでの判定時間
    //その他
    private User               user;
    private OverCharge         overCharge;
    public  B_GameStart        gameStart;
    public  GameJudge          isGamePlaynow;
    private Controller_Input   padController;

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
        this.padController = GetComponent<Controller_Input>();
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームスタートと表示されていない　
        if (this.gameStart.isDrawing()) { return; }
        //ゲームの勝敗がついた
        if (CheckWinStateJudge()) { return; }
        //勝利判定(true:勝敗決定)
        if (CheckWinJudge()) { return; }
        //バッテリーが充電量が負になる場合、初期値へ
        BatteryInit();
        //バッテリー率の減算
        SubBatteryRate();
        //状態に応じたバッテリーの処理
        StateBehavior();
        //チャージカウンタを%変換
        this.CountfromRate();
        //入力の更新
        this.padController.Buttons_Check();
    }

    ///////////////////////////////////////////////
    //状態に応じた振る舞いを行います
    //////////////////////////////////////////////
    /// 状態に応じた処理
    void StateBehavior()
    {
        switch (this.overCharge.getStateName())
        {
            case "Normal":
                //ボタンの入力判定
                this.BatteryChargeCount();
                break;
            case "Adjustment":
                this.BatteryChargeCount();
                break;
            case "OverChargeCount":
                this.BatteryChargeCount();
                if(!CheckAllButtonPush())
                {
                    this.nonbuttoninputCount += Time.deltaTime * 4.5f;
                }
                //充電機能
                //キーボード離れたときのカウンタ
                if (this.nonbuttoninputCount >= 4.0f)
                {
                    this.buttoninputCount -= this.OverChargeDecrement();
                    this.nonbuttoninputCount = 0;
                }
                break;
            case "OverCharge":
                this.user.setMatchDecision(User.WinorLos.Los);
                break;
        }
    }

    //////////////////////////////////////////////////
    //バッテリーに関して
    //main: メイン的な処理
    //sub: サブ的処理
    //////////////////////////////////////////////////
    //main:バッテリーがマイナスなら0にする
    void BatteryInit()
    {
        if (IsBatteryMinus())
        {
            this.batteryRate = 0;
        }
    }
    //main: バッテリー率の減算処理
    void SubBatteryRate()
    {
        int rangeMax = 20;
        if (this.overCharge.getStateName() == "Adjustment") { rangeMax = 50; }
        if(this.overCharge.getStateName() == "OverChargeCount") { rangeMax = 40; }
        int subFlag = Random.Range(1, rangeMax);
        if (subFlag != 1) { return; }
        if(this.buttoninputCount >= 5)
        {
            this.buttoninputCount -= Random.Range(1, 5);
        }
        else
        {
            this.buttoninputCount = 0; //0にしたいなら
        }
    }
    //main:バッテリーの充電を行います
    void BatteryChargeCount()
    {
        //this.buttoninputCount += this.CheckButtonInputCount(); //入力切替
        this.buttoninputCount += this.KeyPushCount();
    }
    //main:Maxのチャージかどうかのチェック
    bool ChargeMax()
    {
        return this.batteryRate == 100;
    }
    //main:バッテリーの割合の取得
    public int getbatteryRate()
    {
        return this.batteryRate;
    }
    //main:押されたボタンのカウントから割合を算出
    void CountfromRate()
    {
        this.batteryRate = this.buttoninputCount;
    }
    //main:オーバーチャージ中のカウント倍率の取得
    int OverChargeDecrement()
    {
        return (int)(5 * this.chargeMagnification * 0.8f);
    }
    //sub:バッテリーがマイナスか判定
    bool IsBatteryMinus()
    {
        return this.batteryRate < 0;
    }
    //sub:オーバーチャージ中かどうかのチェック
    public bool isLimitButtonCheck()
    {
        return this.overchargeButtondownCount >= this.overchargeButtondownMax;
    }
    //sub:オーバーチャージかどうかのチェック
    bool isOverCharge()
    {
        return this.overCharge.Check();
    }
    ///////////////////////////////////////////////////
    //勝敗について
    //main: メイン的な処理
    //sub: サブ的な処理
    ///////////////////////////////////////////////////
    //勝利判定
    //true:勝利　false:判定中
    bool isToWin()
    {
        return this.toWinmaintenanceTime >= this.toWinmaintenancetimeLimit;
    }
    //勝利判定を行います
    //true:勝敗が決まりました false:まだ勝敗が決まりません
    bool CheckWinJudge()
    {
        if (this.ChargeMax())
        {
            this.toWinmaintenanceTime += Time.deltaTime;
            if (this.isToWin())
            {
                //勝利のリザルトへ進む
                this.user.setMatchDecision(User.WinorLos.Win);
                return true;
            }
        }
        return false;
    }
    //勝敗のステートから判定を行います
    //true:勝敗つきました false:勝敗ついてません
    bool CheckWinStateJudge()
    {
        if (!this.isGamePlaynow.isGamePlaynow())
        {
            if (this.user.getWinorLos() == User.WinorLos.Non || this.overCharge.getStateName() == "OverCharge")
            {
                this.user.setMatchDecision(User.WinorLos.Los);
            }
            return true;
        }
        return false;
    }
    ////////////////////////////////////////////////////
    //入力について
    //main: メイン的な処理
    //sub: サブ的な処理
    ////////////////////////////////////////////////////
    //main:キーの入力判定でカウントを増やします
    int KeyPushCount()
    {
        int cnt = 0;
        switch (this.user.getPlayer().ToString())
        {
            case "Player1":
                if (Input.GetKeyDown(KeyCode.A)) { ++cnt; }
                if (Input.GetKeyDown(KeyCode.S)) { ++cnt; }
                if (Input.GetKeyDown(KeyCode.D)) { ++cnt; }
                if (Input.GetKeyDown(KeyCode.F)) { ++cnt; }
                break;
            case "Player2":
                if (Input.GetKeyDown(KeyCode.H)) { ++cnt; }
                if (Input.GetKeyDown(KeyCode.J)) { ++cnt; }
                if (Input.GetKeyDown(KeyCode.K)) { ++cnt; }
                if (Input.GetKeyDown(KeyCode.L)) { ++cnt; }
                break;
        }
        return cnt;
    }
    //main:キーの入力判定で押されていない場合のカウントを増やします
    int KeyUpCount()
    {
        int cnt = 0;
        switch (this.user.getPlayer().ToString())
        {
            case "Player1":
                if (Input.GetKeyUp(KeyCode.A)) { ++cnt; }
                if (Input.GetKeyUp(KeyCode.S)) { ++cnt; }
                if (Input.GetKeyUp(KeyCode.D)) { ++cnt; }
                if (Input.GetKeyUp(KeyCode.F)) { ++cnt; }
                break;
            case "Player2":
                if (Input.GetKeyUp(KeyCode.H)) { ++cnt; }
                if (Input.GetKeyUp(KeyCode.J)) { ++cnt; }
                if (Input.GetKeyUp(KeyCode.K)) { ++cnt; }
                if (Input.GetKeyUp(KeyCode.L)) { ++cnt; }
                break;
        }
        return cnt;
    }
    //main:ボタン判定でカウントを増やします
    int CheckButtonInputCount()
    {
        string[] playerName = new string[2];
        playerName[0] = "PL";
        playerName[1] = "PR";
        int buttonInputCount = 0;
        for (int i = 0; i < 4; ++i)
        {
            if (this.padController.Get_Button_Down(playerName[(int)this.user.getPlayer()], i))
            {
                ++buttoninputCount;
            }
        }
        return buttonInputCount;
    }
    //main:ボタン入力に対してどれくらいのカウントかを取得
    int ButtonInputCount()
    {
        return 1 * this.chargeMagnification;
    }
    //main:ボタンが押されていないカウントの取得
    public float getNonbuttoninputCount()
    {
        return this.nonbuttoninputCount;
    }
    //sub:全てのボタンが押されているかの判定
    bool CheckAllButtonPush()
    {
        //return CheckButtonInputCount() == 0; //入力切替
        return KeyPushCount() == 0;
    }

    //////////////////////////////////////////////
    //外部関数
    //////////////////////////////////////////////
    //勝利プレイヤーの名前の取得
    public string WinnerPlayer()
    {
        return this.gameObject.name;
    }
}
