using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryColor : MonoBehaviour
{

    //基本的な情報
    public BatteryCharge batteryCharge;        //バッテリー情報
    public OverCharge overchargeState;      //現在のスマホの状態
    private short batteryRate;          //バッテリー率を取得して格納する変数

    //マテリアル情報
    private SpriteRenderer nowColor;
    private Color color;

    //大きさの情報
    private float ScaleMax_x;           //最大の横サイズ


    // Use this for initialization
    void Start()
    {
        this.color = GetComponent<SpriteRenderer>().color;
        this.nowColor = GetComponent<SpriteRenderer>();
        this.nowColor.color = new Color();
        this.ScaleMax_x = this.gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.batteryRate = (short)this.batteryCharge.getbatteryRate();
        this.nowColor.color = this.CreateBatteryColor();
        this.transform.localScale = new Vector2(this.GageScale(), this.gameObject.transform.localScale.y);
    }

    Color CreateBatteryColor()
    {
        Color color = new Color();
        switch (this.overchargeState.getStateName())
        {
            //正常状態
            case "Normal":
                color = Color.green;
                break;
            case "Adjustment":
                color = Color.yellow;
                break;
            case "OverChargeCount":
                color = Color.red;
                break;
            case "OverCharge":
                color = Color.red;
                break;
        }
        Debug.Log("現在の色　" + color);
        return color;
    }

    float GageScale()
    {
        return this.ScaleMax_x * this.batteryRate / 100;
    }
}
