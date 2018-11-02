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

	// Use this for initialization
	void Start () {
        if (CommonData.CheckWinState(CommonData.CommonState.Player1,CommonData.GetNowGameCnt()))
        {
            //左が負けで、右が勝ち
            leftImage.GetComponent<Image>().sprite = winSprite;
            rightImage.GetComponent<Image>().sprite = loseSprite;
        }
        else if (CommonData.CheckWinState(CommonData.CommonState.Player1, CommonData.GetNowGameCnt()))
        {
            //左が勝ちで、右が負け
            leftImage.GetComponent<Image>().sprite = loseSprite;
            rightImage.GetComponent<Image>().sprite = winSprite;
        }
        else if (CommonData.CheckWinState(CommonData.CommonState.Player1, CommonData.GetNowGameCnt()))
        {
            //どちらも、引き分けを出す
            leftImage.GetComponent<Image>().sprite = drawSprite;
            rightImage.GetComponent<Image>().sprite = drawSprite;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
