using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColor : MonoBehaviour {

    //private:
    Color color;
    Vector3 pushCount;

    //public:
    public int playerNumber = 0;
    public MonitaSysmtem system;

	// Use this for initialization
	void Start () {
        color.r = 1.0f;
        color.b = 1.0f;
        color.g = 1.0f;   
    }
	
	// Update is called once per frame
	void Update () {
        if(system.IsResultOn())
        {
            Init();
        }
        if (system.IsPlayerOn())
        {
            switch (playerNumber)
            {
                case 1: Push(); break;
                case 2: Push2(); break;
            }
            color.r = (pushCount.x / 10.0f);
            color.g = (pushCount.y / 10.0f);
            color.b = (pushCount.z / 10.0f);
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(
         color.r, color.g, color.b);     
    }

    void Push()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            pushCount.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            pushCount.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            pushCount.z += 1;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            pushCount.x = 0;
            pushCount.y = 0;
            pushCount.z = 0;
        }
    }

    void Push2()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            pushCount.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            pushCount.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            pushCount.z += 1;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            pushCount.x = 0;
            pushCount.y = 0;
            pushCount.z = 0;
        }
    }

    //プレイヤーが押したボタンの数(r,g,b)
    public Vector3 GetUserPushCount()
    {
        return pushCount;
    }

    //プレイヤーの現在の色情報を取得
    public Vector3 GetColorData()
    {
        return new Vector3(color.r,color.g,color.b) * 10.0f;
    }

    //初期化
    void Init()
    {
        color.r = 0.0f;
        color.b = 0.0f;
        color.g = 0.0f;
        pushCount.x = 0;
        pushCount.y = 0;
        pushCount.z = 0;
    }
}
