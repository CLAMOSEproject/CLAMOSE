using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetUserColor : MonoBehaviour {

    private Text target;
    public GameObject gameObj;
    playerColor color;
    public string colorName = "non";
    public int playerNumber;


	// Use this for initialization
	void Start () {
        gameObj = GameObject.Find("color" + playerNumber.ToString());
        target = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        color = gameObj.GetComponent<playerColor>();
        switch (colorName)
        {
            case "red":
                target.text = (color.GetUserPushCount().x).ToString();
                break;
            case "blue":
                target.text = (color.GetUserPushCount().y).ToString();
                break;
            case "yellow":
                target.text = (color.GetUserPushCount().z).ToString();
                break;
        }
	}
}
