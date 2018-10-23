using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
    //基本的な情報
    private int  batteryRate;
    private int  buttoninputCount;
    private bool winFlag;
    private OverCharge overCharge;

    //チャージ倍率
    public int chargeMagnification;

    //何カウントで1%にするのか？
    public int OneCountfromRate;

    //バッテリーの減算量
    private float keyUpCount;
    //何もボタン押していないバッテリーの減算率
    public float  keyupbatteryRate;

//オーバーチャージ中

    //ボタンを押していない時間
    private float nonbuttoninputCount;

//その他
    private User  user;

    // Use this for initialization
    void Start()
    {
        this.batteryRate = 0;
        this.buttoninputCount = 0;
        this.winFlag = false;
        this.overCharge = GetComponent<OverCharge>();
        this.keyUpCount = 0;
        this.nonbuttoninputCount = 0;
        this.user = GetComponent<User>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.overCharge.getStateName())
        {
            case "Normal":
                if (this.ChargeMax())
                {
                    this.winFlag = true;
                    Debug.Log("勝者　" + this.WinnerPlayer());

                    //勝利のリザルトへ進む


                }

                if (this.ButtonInputCheck())
                {
                    this.buttoninputCount += this.ButtonInputCount();
                }

                //キーボード操作が離れているとき
                if(this.KeyUP())
                {
                    this.keyUpCount += Time.deltaTime * this.keyupbatteryRate + 0.1f;
                }
                if (this.keyUpCount >= 1.0f)
                {
                    this.buttoninputCount -= (int)this.keyUpCount;
                    this.keyUpCount = 0;
                }
                break;
            case "Adjustment":
                if (this.KeyUP())
                {
                    //調整中のボタン判定回数にも増加させる
                    this.overCharge.AdjastmentButtonCountIncrease(this.ButtonInputCount());
                    this.keyUpCount += Time.deltaTime * this.keyupbatteryRate + 0.3f;
                }
                if (this.keyUpCount >= 3.0f)
                {
                    this.buttoninputCount -= (int)this.keyUpCount;
                    this.keyUpCount = 0;
                }
                break;
            case "OverChargeCount":
                //充電機能
                if (this.ButtonInputCheck())
                {
                    this.buttoninputCount += this.ButtonInputCount();
                }
                //キーボード離れたときのカウンタ
                else
                {
                    this.nonbuttoninputCount += Time.deltaTime;
                }
                if(this.nonbuttoninputCount >= 4.0f)
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
        switch(this.user.getPlayer().ToString())
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
        return (int)(3 * this.chargeMagnification * 0.7f);
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
        this.batteryRate = this.buttoninputCount / this.OneCountfromRate;
    }

    bool isOverCharge()
    {
        return this.overCharge.Check();
    }

    bool KeyUP()
    {
        bool keyupFlag = false;
        switch(this.user.getPlayer().ToString())
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
}
