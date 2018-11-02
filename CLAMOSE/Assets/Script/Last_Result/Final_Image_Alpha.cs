using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_Image_Alpha : MonoBehaviour
{
    //透明度数値
    float alpha;
    //カンバスサイズ
    float canvas_X, canvas_Y;
    //だんだん透明度が上がる処理を始めるフラグ
    bool increment_Flag;

    //だんだん透明度が上がる処理を始める
    public void Increment_Start()
    {
        increment_Flag = true;
    }

    //イメージに適用
    void Set_Alpha()
    {
        //現在の色を取る
        Color c = GetComponent<Image>().color;

        //透明度更新
        c.a = alpha;

        //適用
        GetComponent<Image>().color = c;
    }

    // Use this for initialization
    void Start ()
    {
        //初期透明度
        alpha = 0.0f;
        //初期フラグ
        increment_Flag = false;

        //カンバスサイズを取る
        canvas_X = transform.parent.GetComponent<RectTransform>().rect.width;
        canvas_Y = transform.parent.GetComponent<RectTransform>().rect.height;

        //画像サイズ更新
        Vector2 size = new Vector2(canvas_X, canvas_Y);
        GetComponent<RectTransform>().sizeDelta = size;


    }
	
	// Update is called once per frame
	void Update ()
    {
		if(increment_Flag)
        {
            alpha += 0.1f;
        }
        //透明度適用
        Set_Alpha();
	}
}
