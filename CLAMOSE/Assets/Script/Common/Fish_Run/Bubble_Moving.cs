using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Moving : MonoBehaviour
{
    //上に浮かび上がる速度
    Vector3 up_Speed;
    float x_Speed;
    //生成サウンド
    public GameObject bubble_Sound;
    //生成されてからの時間
    int time_Count;
    //カメラとの相対位置
    float to_Camera_X;
    
    public void Set_X(float x)
    {
        //画面サイズ
        float screen_Wide, screen_Hight;
        screen_Wide = 60.0f;
        screen_Hight = 20.0f;
        //X座標をカメラを中心にランダム出現
        Vector3 start_Pos = new Vector3(x,0,28);
        to_Camera_X = Random.Range(-screen_Wide / 2.0f, screen_Wide / 2.0f);
        //start_Pos.x += to_Camera_X;
        //start_Pos.y -= screen_Hight / 2.0f;        

        //泡の位置初期化
        transform.position = start_Pos;

        //速度初期化
        x_Speed = Random.Range(1, 4);
        up_Speed = new Vector3(0, 0.5f, 0);

        //カウント初期化
        time_Count = 0;
    }

    // Use this for initialization
    void Start ()
    {
        //サウンド再生
        Instantiate(bubble_Sound).transform.SetParent(this.transform);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //移動
        this.transform.position += up_Speed;
        //カウント上昇
        time_Count++;

        if(time_Count > 300)
        {
            Destroy(this.gameObject);
        }
	}
}
