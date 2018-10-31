using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSelect : MonoBehaviour {


    //private:
    Vector3 colorData;
    Color color;
    // Use this for initialization
    void Start () {
        
        color.r = (colorData.x + colorData.y) / 10.0f;
        color.b = colorData.z / 10.0f;
        color.g = colorData.y / 10.0f;
        //モニタから受け取った色情報を表示します
        gameObject.GetComponent<SpriteRenderer>().color = new Color(
         color.r, color.g, color.b);
        
    }

    // Update is called once per frame
    void Update () {
       
    }

    //色情報を取得します
    public Vector3 GetColorData()
    {
        return new Vector3(color.r,color.g,color.b) * 10;
    }

    //色情報を受け取ります
    public void SetColorData(Vector3 color)
    {
        colorData = color;
    }
}
