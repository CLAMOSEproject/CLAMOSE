using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Pointer : MonoBehaviour
{
    //プレイヤ
    public GameObject player;
    public bool is_Left_Player;
    //ゴール
    public GameObject goal;
    //スタートの時の相対距離
    float start_Distance;
    //相対距離
    float distance;
    //カンバスサイズ
    int canvas_Width;
    int canvas_Height;

    int time_Count;

    //相対距離計算
    void Calculate_Distance()
    {
        float p_X = player.transform.position.x;
        float g_X = goal.transform.position.x;

        //目的地ー現在位置
        distance = g_X - p_X;
    }
    
	// Use this for initialization
	void Start ()
    {
        time_Count = 0;
        canvas_Width = (int)transform.parent.GetComponent<RectTransform>().rect.width;
        canvas_Height = (int)transform.parent.GetComponent<RectTransform>().rect.height;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(player.active == false)
        { return; }
        //相対距離計算
        Calculate_Distance();

        if(time_Count == 5)
        {
            start_Distance = distance;
        }

        //現在の比率計算
        float persent = distance / start_Distance;

        //＋距離なら右方向行きー距離なら左方向行き
        if(distance<0.0f)
        {
            //大きい魚なら比率を増やす
            if(!is_Left_Player)
            {
                persent += 0.03f;
            }
            //左方向行き
            Vector3 pos = new Vector3(canvas_Width * persent, canvas_Height-20, 0);           
            
            this.transform.position = pos;
        }
        else
        {
            //大きい魚なら比率を増やす
            if (is_Left_Player)
            {
                persent += 0.03f;
            }
            //右方向行き
            Vector3 pos = new Vector3(canvas_Width - (canvas_Width * persent), canvas_Height-20, 0);
            
            this.transform.position = pos;
        }

        time_Count++;
    }
}
