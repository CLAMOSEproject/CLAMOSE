using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryColor : MonoBehaviour
{

    //基本的な情報
    public BatteryCharge batteryCharge;     //バッテリー情報
    public OverCharge overchargeState;      //現在のスマホの状態
    private short batteryRate;              //バッテリー率を取得して格納する変数

    //マテリアル情報
    private SpriteRenderer nowColor;
    private Color color;

    //大きさの情報
    private float ScaleMax_x;           //最大の横サイズ
    RectTransform rectTransform;

    // Use this for initialization
    void Start()
    {
        this.color = GetComponent<SpriteRenderer>().color;
        this.nowColor = GetComponent<SpriteRenderer>();
        this.rectTransform = GetComponent<RectTransform>();
        this.ScaleMax_x = GetComponent<RectTransform>().transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.batteryRate = (short)this.batteryCharge.getbatteryRate();
        this.color = this.GageCheck();
        this.nowColor.color = this.color;
        this.rectTransform.transform.localScale = new Vector2(this.GageScale(), this.rectTransform.localScale.y);
    }

    Color GageCheck()
    {
        Color color = new Color();
        if(this.batteryRate < 30)
        {
            color = Color.green;
        }
        else if(this.batteryRate < 70)
        {
            color = new Color(115 / 255, 255 / 255, 0,255/255);
        }
        else if(this.batteryRate < 100)
        {
            color = Color.yellow;
        }
        else if (this.batteryRate == 100)
        {
            color = Color.blue;
            return color;
        }
        else
        {
            color = Color.red;
        }
        return color;
    }

    float GageScale()
    {
        if(this.batteryRate <= 100)
        {
            return this.ScaleMax_x * this.batteryRate / 100;
        }
        return this.ScaleMax_x;
    }
}
