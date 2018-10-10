using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
    private int  batteryRate;
    private int  buttoninputCount;
    private bool winFlag;

    //チャージ倍率
    public int chargeMagnification;

    //何カウントで1%にするのか？
    public int OneCountfromRate;

    // Use this for initialization
    void Start()
    {
        this.batteryRate = 0;
        this.buttoninputCount = 0;
        this.winFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.ChargeMax())
        {
            this.winFlag = true;
            Debug.Log("勝者　" + this.WinnerPlayer());
        }

        if (this.ButtonInputCheck())
        {
            this.buttoninputCount += this.ButtonInputCount();
            this.CountfromRate();
        }
        Debug.Log(this.batteryRate + "％");
    }

    //ボタンの判定
    bool ButtonInputCheck()
    {
        return Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B);
    }

    int ButtonInputCount()
    {
        return 1 * this.chargeMagnification;
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
}
