using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_Scaler : MonoBehaviour
{
    //カンバスのサイズ
    float canvas_X, canvas_Y;
    //ロゴのサイズ
    Vector2 logo_Size;
    //最大のロゴサイズ
    Vector2 logo_Size_Max;

    //タイムカウント
    public int pump_Time;
    int time_Count;

	// Use this for initialization
	void Start ()
    {
        //カンバスサイズを取る
        canvas_X = transform.parent.GetComponent<RectTransform>().rect.width;
        canvas_Y = transform.parent.GetComponent<RectTransform>().rect.height;

        //各サイズに代入
        logo_Size_Max = new Vector2(canvas_X / 4.0f * 3.0f, canvas_Y / 4.0f * 3.0f);
        logo_Size = logo_Size_Max;

        //カウント初期化
        time_Count = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //カウントに応じて最大サイズに戻す
        if(time_Count > pump_Time)
        {
            logo_Size = logo_Size_Max;
            time_Count = 0;
        }
        else
        {
            logo_Size -= new Vector2(1, 1);
        }

        //画像サイズ更新
        GetComponent<RectTransform>().sizeDelta = logo_Size;

        //カウント上昇
        time_Count++;
    }
}
