using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winjudge : MonoBehaviour {

    //public
    public Sprite winSprite;
    public Sprite loseSprite;
    public Sprite drawSprite;

    public GameObject leftImage;
    public GameObject rightImage;

    public Text leftText;
    public Text rightText;
	// Use this for initialization
	void Start () {
        if (CommonData.CheckWinState(CommonData.CommonState.Player1, CommonData.GetNowGameCnt()))
        {
            //左が負けで、右が勝ち
            leftImage.GetComponent<Image>().sprite = winSprite;
            leftImage.GetComponent<Image>().color = Color.blue;
            leftText.text = "Lose";
            leftText.color = Color.red;
            rightImage.GetComponent<Image>().sprite = loseSprite;
            rightImage.GetComponent<Image>().color = Color.red;
            rightText.text = "Win";
            rightText.color = Color.blue;
        }
        else if (CommonData.CheckWinState(CommonData.CommonState.Player1, CommonData.GetNowGameCnt()))
        {
            //左が勝ちで、右が負け
            leftImage.GetComponent<Image>().sprite = loseSprite;
            leftImage.GetComponent<Image>().color = Color.red;
            leftText.text = "Win";
            leftText.color = Color.blue;
            rightImage.GetComponent<Image>().sprite = winSprite;
            rightImage.GetComponent<Image>().color = Color.blue;
            rightText.text = "Lose";
            rightText.color = Color.red;
        }
        else if (CommonData.CheckWinState(CommonData.CommonState.Player1, CommonData.GetNowGameCnt()))
        {
            //どちらも、引き分けを出す
            leftImage.GetComponent<Image>().sprite = drawSprite;
            leftImage.GetComponent<Image>().color = Color.green;
            leftText.text = "Draw";
            leftText.color = Color.black;
            rightImage.GetComponent<Image>().sprite = drawSprite;
            rightImage.GetComponent<Image>().color = Color.green;
            rightText.text = "Draw";
            rightText.color = Color.black;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
