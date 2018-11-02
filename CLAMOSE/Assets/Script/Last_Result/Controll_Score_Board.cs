using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controll_Score_Board : MonoBehaviour
{
    //このラウンドでだれが勝ったかを保存する場所
    int win_State;
    //位置計算のためにラウンド数を保存
    public int round;
    //カンバスサイズ
    float canvas_X, canvas_Y;

    //透明度下がりが始まるフラグ
    bool decrement_Flag;
    //透明度
    float alpha;

    //使うイメージ
    public Sprite[] last_Result;
    public Sprite[] round1_Sprite;
    public Sprite[] round2_Sprite;
    public Sprite[] round3_Sprite;

    public void Decrement_Start()
    {
        decrement_Flag = true;
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

    //ステートを保存してもらうメソッド
    public void Set_Winner(int winner)
    {
        if (winner == 4)
        {
            win_State = 2;
        }
        else
        {
            win_State = winner;
        }
        alpha = 1.0f;
    }
    //イメージ選択
    void Select_Image()
    {
        switch(round)
        {
            case 1:
                GetComponent<Image>().sprite = round1_Sprite[win_State];
                break;
            case 2:
                GetComponent<Image>().sprite = round2_Sprite[win_State];
                break;
            case 3:
                GetComponent<Image>().sprite = round3_Sprite[win_State];
                break;
            case 4:
                GetComponent<Image>().sprite = last_Result[win_State];
                break;
        }
    }

    // Use this for initialization
    void Start ()
    {
        decrement_Flag = false;
        alpha = 1.0f;
        //カンバスサイズ保存
        canvas_X = transform.parent.GetComponent<RectTransform>().rect.width;
        canvas_Y = transform.parent.GetComponent<RectTransform>().rect.height;

        //Y位置計算
        float y = (canvas_Y / 5.0f) * (5-round);

        //位置更新
        Vector3 pos = new Vector3(canvas_X / 2.0f, y, 0);

        transform.position = pos;        
    }

   
	
	// Update is called once per frame
	void Update ()
    {
        if (decrement_Flag)
        {
            alpha -= 0.5f;
        }
        Set_Alpha();

        Select_Image();
    }
}
