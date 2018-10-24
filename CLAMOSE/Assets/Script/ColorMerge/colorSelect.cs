using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSelect : MonoBehaviour {


    //private:
    Vector3 colorData;

    // Use this for initialization
    void Start () {
        //モニタから受け取った色情報を表示します
        gameObject.GetComponent<SpriteRenderer>().color = new Color(
         colorData.x / 10.0f, colorData.y / 10.0f, colorData.z / 10.0f);
    }

    // Update is called once per frame
    void Update () {
    
	}

    //色情報を取得します
    public Vector3 GetColorData()
    {
        return colorData;
    }

    //色情報を受け取ります
    public void SetColorData(Vector3 color)
    {
        colorData = color;
    }
}
