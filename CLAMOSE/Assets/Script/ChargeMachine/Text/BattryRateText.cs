using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattryRateText : MonoBehaviour {

    public Sprite[] mathFont = new Sprite[10];
    public BatteryCharge batteryRate;
    public int magicNumber;

    private Sprite Mathsprite;
    private Image  image;
	// Use this for initialization
	void Start ()
    {
        this.Mathsprite = GetComponent<Image>().sprite;
        this.image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.Mathsprite = this.MagicNumberfromSelectMathFont();
        this.image.sprite = this.Mathsprite;
    }

    Sprite MagicNumberfromSelectMathFont()
    {
        string digit = this.batteryRate.getbatteryRate().ToString();
        Debug.Log(digit);
        int spriteNumber = int.Parse(digit.Substring(this.magicNumber));
        if(int.Parse(digit.Substring(this.magicNumber)) >= 11)
        {
            Debug.Log("アウト");
        }
        return this.mathFont[spriteNumber];
    }
}
