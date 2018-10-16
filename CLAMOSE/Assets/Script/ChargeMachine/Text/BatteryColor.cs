using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryColor : MonoBehaviour {

    //基本的な情報
    private BatteryCharge batteryCharge;
    private OverCharge    overchargeState;
    private short         batteryRate;
    private Material      material;
    private Color         chengeColor;

    //緑の大きさについて
    private 

	// Use this for initialization
	void Start ()
    {
        this.batteryCharge = GetComponent<BatteryCharge>();
        this.material = GetComponent<Material>();
        this.chengeColor = GetComponent<Material>().color;
        this.overchargeState = GetComponent<OverCharge>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.batteryRate = (short)this.batteryCharge.getbatteryRate();
	}

    void CreateBatteryColor()
    {
        switch (this.overchargeState.getStateName())
        {
            //正常状態
            case "Normal":
                this.chengeColor = new Color(0, 255, 0);
                break;
            case "Adjustment":
                break;
            case "OverChargeCount":
                this.chengeColor = new Color(255, 0, 0);
                break;
            case "OverCharge":
                break;
        }
    }
}
