using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Vector3 pos = new Vector3(580 * persent, 300, 0);           
            
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
            Vector3 pos = new Vector3(580-(580 * persent), 300, 0);
            
            this.transform.position = pos;
        }

        time_Count++;
    }
}
