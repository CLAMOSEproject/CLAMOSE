using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetThemeColor : MonoBehaviour {

    private Text target;
    public GameObject gameObj;
    public colorSelect colorSelect;
    public string colorName = "non";

    // Use this for initialization
    void Start () {
        gameObj = GameObject.Find("themeColor");
        colorSelect = gameObj.GetComponent<colorSelect>();

        target = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (colorName)
        {
            case "red":
                target.text = (colorSelect.GetColorData().x).ToString();
                break;
            case "blue":
                target.text = (colorSelect.GetColorData().y).ToString();
                break;
            case "yellow":
                target.text = (colorSelect.GetColorData().z).ToString();
                break;
        }
	}
}
