using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VATfunction : MonoBehaviour
{
    //変数
    //プレイヤの名前
    public string players_Name;
    //重さ
    public float mase;
    //速度
    float speed;
    //仮の方向
    Vector3 angle;
    //進行方向を確認するフラグ
    public bool Is_Going_Left;
    //泡のプレハブ
    public GameObject bubble;
    
    //左プレイヤ用ダウンフラグ
    bool[] hs_Flag = new bool[4];
    //各ボタン
    int[] pl_Buttons = new int[4];
    int[] pr_Buttons = new int[4];
    float prev_Axis5, prev_Axis6;

    //KeyDownと同じくするために
    bool Head_Switch_Down(int but_Num)
    {
        bool rtv = false;
        switch(but_Num)
        {
            //左
            case 0:
                if(prev_Axis5 == 0.0f && Input.GetAxis("Axis 5") < 0.0f)
                {
                    //prev_Axis5 = Input.GetAxis("Axis 5");
                    rtv = true;
                }
                else
                {
                    //prev_Axis5 = Input.GetAxis("Axis 5");
                    rtv = false;
                }
                break;
            //右
            case 2:
                if (prev_Axis5 == 0.0f && Input.GetAxis("Axis 5") > 0.0f)
                {
                    //prev_Axis5 = Input.GetAxis("Axis 5");
                    rtv = true;
                }
                else
                {
                    //prev_Axis5 = Input.GetAxis("Axis 5");
                    rtv = false;
                }
                break;
            //上
            case 3:
                if (prev_Axis6 == 0.0f && Input.GetAxis("Axis 6") > 0.0f)
                {
                    //prev_Axis6 = Input.GetAxis("Axis 6");
                    rtv = true;
                }
                else
                {
                    //prev_Axis6 = Input.GetAxis("Axis 6");
                    rtv = false;
                }
                break;
            //下
            case 1:
                if (prev_Axis6 == 0.0f && Input.GetAxis("Axis 6") < 0.0f)
                {
                    //prev_Axis6 = Input.GetAxis("Axis 6");
                    rtv = true;
                }
                else
                {
                    //prev_Axis6 = Input.GetAxis("Axis 6");
                    rtv = false;
                }
                break;
            //ボタン範囲を超えたものが入ったらfalseを返す            
        }
        
        return rtv;
    }
    void Buttons_Check()
    {
        //左のプレイヤ        

        //左右チェック
        if (this.Head_Switch_Down(0))
        {
            this.pl_Buttons[0]++;
            this.hs_Flag[0] = true;
            this.hs_Flag[2] = false;
            //Debug.Log("check");
            Instantiate(bubble);
        }
        if (this.Head_Switch_Down(2))
        {
            this.pl_Buttons[2]++;
            this.hs_Flag[2] = true;
            this.hs_Flag[0] = false;
            //Debug.Log("check");
            Instantiate(bubble);
        }
        //上下チェック
        if (this.Head_Switch_Down(3))
        {
            this.pl_Buttons[3]++;
            this.hs_Flag[3] = true;
            this.hs_Flag[1] = false;
            //Debug.Log("check");
            Instantiate(bubble);
        }
        if (this.Head_Switch_Down(1))
        {
            this.pl_Buttons[1]++;
            this.hs_Flag[1] = true;
            this.hs_Flag[3] = false;
            //Debug.Log("check");
            Instantiate(bubble);
        }
        prev_Axis5 = Input.GetAxis("Axis 5");
        prev_Axis6 = Input.GetAxis("Axis 6");
        //何も押されてないんだったら全ボタンを０にする
        //if (Input.GetAxis("Axis 5") == 0.0f && Input.GetAxis("Axis 6") == 0.0f)
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        this.pl_Buttons[i] = 0;
        //        this.hs_Flag[i] = false;
        //    }
        //}

        //右のプレイヤ

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            this.pr_Buttons[0]++;
            //Debug.Log("check");
            Instantiate(bubble);
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            this.pr_Buttons[1]++;
            //Debug.Log("check");
            Instantiate(bubble);
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            this.pr_Buttons[2]++;
            //Debug.Log("check");
            Instantiate(bubble);
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            this.pr_Buttons[3]++;
            //Debug.Log("check");
            Instantiate(bubble);
        }
        //if(Input.GetKeyDown(KeyCode.JoystickButton0) == false && Input.GetKeyDown(KeyCode.JoystickButton0) == false && Input.GetKeyDown(KeyCode.JoystickButton1) == false && Input.GetKeyDown(KeyCode.JoystickButton2) == false && Input.GetKeyDown(KeyCode.JoystickButton3) == false)
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        this.pr_Buttons[i] = 0;
        //    }
        //}

    }
    //getter
    //押した回数全体をもらう
    public int Get_Masshed_Button_All(string name)
    {
        //前回数を足して返す
        int masshed = 0;

        switch (name)
        {
            case "PL":
                for (int i = 0; i < 4; i++)
                {
                    masshed += this.pl_Buttons[i];
                }
                break;
            case "PR":
                for (int i = 0; i < 4; i++)
                {
                    masshed += this.pr_Buttons[i];
                }
                break;
        }

        return masshed;
    }

    public int Get_Masshed_Button_One(string name, int but_Num)
    {
        //指定したボタンの押した回数を返す
        switch (name)
        {
            case "PL":
                if (but_Num > 3 || but_Num < 0)
                {
                    return 0;
                }
                else
                {
                    return this.pl_Buttons[but_Num];
                }
                break;
            case "PR":
                if (but_Num > 3 || but_Num < 0)
                {
                    return 0;
                }
                else
                {
                    return this.pr_Buttons[but_Num];
                }
                break;
        }
        return 0;
    }
    //setter
    public void Set_Players_Name(string name)
    {
        this.players_Name = name;
    }
    //メソッド
    //加速度算出メソッド
    private float Acceleration(int hit_Num)
    {
        //重いものならもっと多く加速できる
        float acc = (-1.0f / mase * hit_Num) + 10 - mase;
        //-加速はさせない
        if(acc < 0.0f)
        {
            acc = 0.0f;
        }

        return acc;
    }
    //移動加速
    private void Accelerate_Speed(int hit_Num)
    {
        //加速は＋範囲
        if(((-1.0f / mase * hit_Num) + mase) <= 0.0f)
        {
            return;
        }
        //V=A*T
        this.speed = (-hit_Num * hit_Num) / (2 * mase) + (mase * hit_Num);
    }

    //進行方向をもらうメソッド
    public float Get_Angle_X()
    {
        return this.angle.x;
    }

	// Use this for initialization
	void Start ()
    {
        if (this.Is_Going_Left)
        {
            this.angle = new Vector3(-1, 0, 0);
        }
        else
        {
            this.angle = new Vector3(1, 0, 0);
        }
        this.speed = 0.0f;
        //ボタンを押した回数を初期化
        for (int i = 0; i < 4; i++)
        {
            this.pr_Buttons[i] = 0;
            this.pl_Buttons[i] = 0;
            this.hs_Flag[i] = false;
        }
        this.prev_Axis5 = 0.0f;
        this.prev_Axis6 = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //フレームごとにボタンチェック
        this.Buttons_Check();
        int hn = Get_Masshed_Button_All(this.players_Name);
        //加速
        this.Accelerate_Speed(hn);
        //移動        
        this.transform.position += this.angle * this.speed / 10;
        

        //テストで連打数上昇
        //this.test_Hit++;
        if (this.players_Name == "PL")
        {
            //Debug.Log(this.players_Name);
            //Debug.Log(this.speed);
        }
      
    }
}
