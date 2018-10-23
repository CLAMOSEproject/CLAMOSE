﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverCharge : MonoBehaviour
{

    private BatteryCharge batteryChargeRate;

    private enum State
    {
        Normal,
        Adjustment,
        OverChargeCount,
        OverCharge
    }

    State overchargeState;

    //通常の爆発判定時間
    public int overchargelimitTime;
    private int overchargeinitiallimitTime;
    float overchargetimeCount;

    //調整中に行われるボタン回数
    private int adjastmentbuttonLimitCount;
    public int adjastmentCountRange;

    //調整中に入るタイミング
    public int adjastmentTiming;

    // Use this for initialization
    void Start()
    {
        this.overchargeinitiallimitTime = this.overchargelimitTime;
        this.batteryChargeRate = GetComponent<BatteryCharge>();
        this.overchargeState = State.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        State chengeState = this.overchargeState;

        switch (this.overchargeState)
        {
            case State.Normal:
                //判定
                if (this.AdjastmentCheck())
                {
                    chengeState = State.Adjustment;
                }
                if (this.Check())
                {
                    chengeState = State.OverChargeCount;
                }
                break;
            case State.Adjustment:
                //指定範囲のボタンを回数を超えた
                if (this.isAdjastmentButtonLimit())
                {
                    this.adjastmentbuttonLimitCount = 0;
                    chengeState = State.OverChargeCount;
                }
                Debug.Log("指定範囲中" + this.adjastmentbuttonLimitCount);
                break;
            case State.OverChargeCount:
                if (!this.Check() && this.batteryChargeRate.getNonbuttoninputCount() >= 4.0f)
                {
                    chengeState = State.Normal;
                }
                else
                {
                    //爆発判定
                    if (this.overchargelimitTime <= 0)
                    {
                        chengeState = State.OverCharge;
                        Debug.Log("爆発");
                    }
                    //カウント減らし
                    this.overchargetimeCount += Time.deltaTime;
                    if (this.overchargetimeCount >= 1.0f)
                    {
                        this.overchargetimeCount = 0;
                        this.overchargelimitTime -= 1;
                    }
                    Debug.Log("残り爆発まで" + this.overchargelimitTime + "秒");
                }
                break;
            case State.OverCharge:
                //エフェクトへ続く
                break;
        }

        this.overchargeState = chengeState;
    }

   　//オーバーチャージに入るか？

    public bool Check()
    {
        return this.batteryChargeRate.getbatteryRate() > 100;
    }

    //Enumを返す
    public string getStateName()
    {
        return this.overchargeState.ToString();
    }

    //調整期間に関するもの

    public bool isAdjastmentButtonLimit()
    {
        return this.adjastmentbuttonLimitCount >= this.adjastmentCountRange;
    }

    public void AdjastmentButtonCountIncrease(int count)
    {
        this.adjastmentbuttonLimitCount += count;
    }

    //調整範囲を超えていないか？
    private bool AdjastmentCheck()
    {
        return this.batteryChargeRate.getbatteryRate() >= this.adjastmentTiming;
    }
}
