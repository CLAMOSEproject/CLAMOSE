using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
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
                }

                if (this.ButtonInputCheck())
                {
                    this.buttoninputCount += this.ButtonInputCount();
                    if(this.keyUpCount >= 1.0f)
                    {
                        this.buttoninputCount -= (int)this.keyUpCount;
                        this.keyUpCount = 0;
                    }
                }
                if(this.KeyUP())
                {
                    this.keyUpCount += Time.deltaTime * this.keyupbatteryRate + 0.3f;
                }
                break;
            case "Adjustment":
                if(this.KeyUP())
                {
                    //調整中のボタン判定回数にも増加させる
                    this.overCharge.AdjastmentButtonCountIncrease(this.ButtonInputCount());
                }
                break;
            case "OverChargeCount":

                //1フレームずつ調整が入る
                if(!this.ButtonInputCheck())
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
                return Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B);
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
        return Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.B);
    }
}
