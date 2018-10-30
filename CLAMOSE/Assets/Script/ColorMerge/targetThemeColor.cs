using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetThemeColor : MonoBehaviour {

    private Text target;
    public GameObject gameObj;
    public monitaData monita;
    public string colorName = "non";
    
    // Use this for initialization
    void Start () {
        monita = gameObj.GetComponent<monitaData>();
        target = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        switch (colorName)
        {
            case "red":
                target.text = (monita.GetColorData().x).ToString();
                break;
            case "blue":
                target.text = (monita.GetColorData().z).ToString();
                break;
            case "yellow":
                target.text = (monita.GetColorData().y).ToString();
                break;
        }
    }
}
