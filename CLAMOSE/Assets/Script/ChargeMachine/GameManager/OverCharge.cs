using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverCharge : MonoBehaviour {

    private BatteryCharge batteryChargeRate;

    private enum State
    {
        Normal,
        OverChargeCount,
        OverCharge
    }

    State overchargeState;

    public  int  overchargelimitTime;
    private int  overchargeinitiallimitTime;
    float        overchargetimeCount;

    private bool overchargeFlag;

	// Use this for initialization
	void Start ()
    {
        this.overchargeinitiallimitTime = this.overchargelimitTime;
        this.overchargeFlag = false;
        this.batteryChargeRate = GetComponent<BatteryCharge>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        State chengeState = this.overchargeState;

        switch (this.overchargeState)
        {
            case State.Normal:
                if (this.Check())
                {
                    chengeState = State.OverChargeCount;
                }
                break;
            case State.OverChargeCount:
                if(!this.Check())
                {
                    this.LimitReset();
                    chengeState = State.Normal;
                }
                if (this.overchargelimitTime <= 0)
                {
                    chengeState = State.OverCharge;
                    Debug.Log("爆発");
                }
                this.overchargetimeCount += Time.deltaTime;
                if(this.overchargetimeCount >= 1.0f)
                {
                    this.overchargetimeCount = 0;
                    this.overchargelimitTime -= 1; 
                }
                Debug.Log(this.overchargelimitTime);
                break;
            case State.OverCharge:
                this.LimitReset();
                this.overchargeFlag = true;
                //エフェクトへ続く
                break;
        }

        this.overchargeState = chengeState;
	}

    bool Check()
    {
        return this.batteryChargeRate.getbatteryRate() > 100;
    }

    public bool getOverChargeFlag()
    {
        return this.overchargeFlag;
    }

    void LimitReset()
    {
        this.overchargetimeCount = 0.0f;
        this.overchargelimitTime = this.overchargeinitiallimitTime;
    }
}
