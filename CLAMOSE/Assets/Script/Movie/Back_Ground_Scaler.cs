using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back_Ground_Scaler : MonoBehaviour
{
    //位置
    Vector2 pos;
    //カンバスサイズ
    float canvas_X, canvas_Y;

	// Use this for initialization
	void Start ()
    {
        //カンバスサイズを取る
        canvas_X = transform.parent.GetComponent<RectTransform>().rect.width;
        canvas_Y = transform.parent.GetComponent<RectTransform>().rect.height;

        pos = new Vector2(canvas_X / 2.0f, canvas_Y / 2.0f);

        //サイズと位置を更新
        transform.position = pos;

        GetComponent<RectTransform>().sizeDelta = new Vector2(canvas_X, canvas_Y);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
