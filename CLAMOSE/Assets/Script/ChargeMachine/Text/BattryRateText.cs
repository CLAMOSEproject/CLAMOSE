using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattryRateText : MonoBehaviour {

    public Sprite[] mathFont = new Sprite[11];
    public BatteryCharge batteryRate;
    public int magicNumber;

    private Sprite    Mathsprite;
    private Image     image;

    public  bool      percent;
    // Use this for initialization
    void Start ()
    {
        this.Mathsprite = GetComponent<Image>().sprite;
        this.image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //sprite表示
        if(!this.percent)
        {
            this.Mathsprite = this.MagicNumberfromSelectMathFont();
            this.image.sprite = this.Mathsprite;
        }
        else
        {
            this.Mathsprite = this.mathFont[10];
        }
    }

    Sprite MagicNumberfromSelectMathFont()
    {
        string digit = this.batteryRate.getbatteryRate().ToString();
        //バッテリー率のデータ取得

        short spriteNumber = 0;
        if(this.magicNumber <= digit.Length)
        {
            this.image.enabled = true;
            spriteNumber = short.Parse(digit.Substring(digit.Length - this.magicNumber, 1));
        }
        else
        {
            this.image.enabled = false;
        }
        return this.mathFont[spriteNumber];
    }
}
