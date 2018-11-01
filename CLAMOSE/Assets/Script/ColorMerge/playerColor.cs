using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColor : MonoBehaviour {

    //private:
    Color color;
    Vector3 pushCount;
    const int MaxPushCount = 9;
    //public:
    public int playerNumber = 0;
    public MonitaSysmtem system;
    public GameObject inputSystem;

    //audio
    public AudioSource cancelSound;

    enum EffectColor
    {
        Red = 0,
        Blue = 1,
        Yellow = 2,
    }
    //エフェクト用のペン
    public GameObject[] effectPen;
    
	// Use this for initialization
	void Start () {
        color.r = 0.0f;
        color.b = 0.0f;
        color.g = 0.0f;
        foreach(GameObject g in effectPen)
        {
            g.GetComponent<TimeCnt>().SetLimitTime(30.0f);
            g.SetActive(false);
        }
        //audio
        cancelSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(system.IsResultOn() || system.IsEndOn())
        {
            Init();
        }
        if (system.IsPlayerOn())
        {
            switch (playerNumber)
            {
                case 1: Push(); break;
                case 2: Push2(); break;
                    //case 1: PushButton1(); break;
                    //case 2: PushButton2(); break;
            }
            RestrictionPush();
           
            color.r = ((pushCount.x + pushCount.z) / 10.0f);
            color.b = (pushCount.y / 10.0f);
            color.g = (pushCount.z / 10.0f);

        }
        this.GetComponent<SpriteRenderer>().color = new Color(
         color.r, color.g, color.b);

        //入力更新
        inputSystem.GetComponent<Controller_Input>().Buttons_Check();
    }

    void Push()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            pushCount.x += 1;
            EffectPenActive((int)EffectColor.Red);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            pushCount.y += 1;
            EffectPenActive((int)EffectColor.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            pushCount.z += 1;
            EffectPenActive((int)EffectColor.Yellow);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            pushCount.x = 0;
            pushCount.y = 0;
            pushCount.z = 0;
            cancelSound.PlayOneShot(cancelSound.clip);
        }
        else
        {
            EffectPenNonActive();
        }
        EffectPenTimeLimit();
    }

    void Push2()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            pushCount.x += 1;
            EffectPenActive((int)EffectColor.Red);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            pushCount.y += 1;
            EffectPenActive((int)EffectColor.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            pushCount.z += 1;
            EffectPenActive((int)EffectColor.Yellow);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            pushCount.x = 0;
            pushCount.y = 0;
            pushCount.z = 0;
            cancelSound.PlayOneShot(cancelSound.clip);
        }
        else
        {
            EffectPenNonActive();
        }
        //一定時間が経過したら、描画をしない、カウントしない、cntリセット
        EffectPenTimeLimit();
    }

    //プレイヤーが押したボタンの数(r,g,b)
    public Vector3 GetUserPushCount()
    {
        return pushCount;
    }

    //プレイヤーの現在の色情報を取得
    public Vector3 GetColorData()
    {
        return pushCount;
    }

    //押すカウントに制限をかける
    void RestrictionPush()
    {
        if(pushCount.x >= MaxPushCount)
        {
            pushCount.x = MaxPushCount;
        }
        if(pushCount.y >= MaxPushCount)
        {
            pushCount.y = MaxPushCount;
        }
        if(pushCount.z >= MaxPushCount)
        {
            pushCount.z = MaxPushCount;
        }
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
        EffectPenNonActive();
    }


    //ボタンデバイスの入力
    //rightPlayer
    void PushButton1()
    {
        if (inputSystem.GetComponent<Controller_Input>().Get_Masshed_Button_One("PR", 0) != 0)
        {
            ++pushCount.x;
            EffectPenActive((int)EffectColor.Red);
        }
        else if (inputSystem.GetComponent<Controller_Input>().Get_Masshed_Button_One("PR", 1) != 0)
        {
            ++pushCount.y;
            EffectPenActive((int)EffectColor.Blue);
        }
        else if (inputSystem.GetComponent<Controller_Input>().Get_Masshed_Button_One("PR", 2) != 0)
        {
            ++pushCount.z;
            EffectPenActive((int)EffectColor.Yellow);
        }
        else if (inputSystem.GetComponent<Controller_Input>().Get_Masshed_Button_One("PR", 3) != 0)
        {
            ResetPushButtonCount();
        }
        else
        {
            EffectPenNonActive();
        }
        EffectPenTimeLimit();
    }
    //leftPlayer
    void PushButton2()
    {
        if(inputSystem.GetComponent<Controller_Input>().Get_Masshed_Button_One("PL", 0) != 0)
        {
            ++pushCount.x;
            EffectPenActive((int)EffectColor.Red);
        }
        else if (inputSystem.GetComponent<Controller_Input>().Get_Masshed_Button_One("PL", 1) != 0)
        {
            ++pushCount.y;
            EffectPenActive((int)EffectColor.Blue);
        }
        else if (inputSystem.GetComponent<Controller_Input>().Get_Masshed_Button_One("PL", 2) != 0)
        {
            ++pushCount.z;
            EffectPenActive((int)EffectColor.Yellow);
        }
        else if (inputSystem.GetComponent<Controller_Input>().Get_Masshed_Button_One("PL", 3) != 0)
        {
            ResetPushButtonCount();
        }
        else
        {
            EffectPenNonActive();
        }
        EffectPenTimeLimit();
    }

    //現在の押されている数のリセット
    void ResetPushButtonCount()
    {
        pushCount.x = 0;
        pushCount.y = 0;
        pushCount.z = 0;
        cancelSound.PlayOneShot(cancelSound.clip);
    }
    /// <summary>
    /// /////////////////////////////////////////
    ///  //処理を簡潔にする関数群
    ///  ////////////////////////////////////////
    /// </summary>
    //EffectPenが非Activeの時
    void EffectPenNonActive()
    {
        foreach (GameObject g in effectPen)
        {
            //g.SetActive(false);
            //g.GetComponent<TimeCnt>().ResetCount();
            if (g.GetComponent<TimeCnt>().IsLimit())
            {
                g.SetActive(false);
                g.GetComponent<TimeCnt>().ResetCount();
                g.GetComponent<TimeCnt>().PlayCount(false);
            }
        }
    }
    //EffectPenがActiveの時
    void EffectPenActive(int penNumber)
    {
        effectPen[penNumber].SetActive(true);
        effectPen[penNumber].GetComponent<TimeCnt>().PlayCount(true);
    }
    //EffectPenが一定時間経過したか判断し、非Activeにする
    void EffectPenTimeLimit()
    {
        //一定時間が経過したら、描画をしない、カウントしない、cntリセット
        foreach (GameObject g in effectPen)
        {
            if (g.GetComponent<TimeCnt>().IsLimit())
            {
                g.SetActive(false);
                g.GetComponent<TimeCnt>().ResetCount();
                g.GetComponent<TimeCnt>().PlayCount(false);
            }
        }
    }
}
