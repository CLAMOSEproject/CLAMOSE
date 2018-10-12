using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSelect : MonoBehaviour {


    Vector3 colorData;
    public int designatePushNum = 3;
    private monitaData monitaData;
    // Use this for initialization
    void Start () {
        Color randColor;
        randColor.r = Random.Range(designatePushNum, 10);
        randColor.g = Random.Range(designatePushNum, 10); 
        randColor.b = Random.Range(designatePushNum, 10);

        colorData = new Vector3(randColor.r,randColor.g,randColor.b);

        monitaData = GetComponent<monitaData>();
        monitaData.SetColorData(colorData);

        gameObject.GetComponent<SpriteRenderer>().color = new Color(
         randColor.r / 10.0f ,randColor.g / 10.0f,randColor.b / 10.0f);
    }

    // Update is called once per frame
    void Update () {
    
	}

    public Vector3 GetColorData()
    {
        return colorData;
    }
}
