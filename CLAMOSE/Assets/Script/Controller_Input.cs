using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Input : MonoBehaviour
{
    //左プレイヤ用ダウンフラグ
    bool[] hs_Flag = new bool[4];
    //各ボタン
    int[] pl_Buttons = new int[4];
    int[] pr_Buttons = new int[4];
    float prev_Axis5, prev_Axis6;
    //プレイヤの名前
    public string players_Name;

    public bool Get_Button_Down(string name, int but_Num)
    {
        if(name == "PL")
        {
            if(Head_Switch_Down(0))
            {
                return true;
            }
            if (Head_Switch_Down(1))
            {
                return true;
            }
            if (Head_Switch_Down(2))
            {
                return true;
            }
            if (Head_Switch_Down(3))
            {
                return true;
            }
        }

        else if(name == "PR")
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                return true;
                //Debug.Log("check");
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                return true;
                //Debug.Log("check");
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                return true;
                //Debug.Log("check");
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                return true;
                //Debug.Log("check");
            }
        }

        return false;
    }

    //KeyDownと同じくするために
    public bool Head_Switch_Down(int but_Num)
    {
        bool rtv = false;
        switch (but_Num)
        {
            //左
            case 0:
                if (prev_Axis5 == 0.0f && Input.GetAxis("Axis 5") < 0.0f)
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
    public void Buttons_Check()
    {
        //左のプレイヤ        

        //左右チェック
        if (this.Head_Switch_Down(0))
        {
            this.pl_Buttons[0]++;
            this.hs_Flag[0] = true;
            this.hs_Flag[2] = false;
            //Debug.Log("check");
        }
        if (this.Head_Switch_Down(2))
        {
            this.pl_Buttons[2]++;
            this.hs_Flag[2] = true;
            this.hs_Flag[0] = false;
            Debug.Log("check");
        }
        //上下チェック
        if (this.Head_Switch_Down(3))
        {
            this.pl_Buttons[3]++;
            this.hs_Flag[3] = true;
            this.hs_Flag[1] = false;
            //Debug.Log("check");
        }
        if (this.Head_Switch_Down(1))
        {
            this.pl_Buttons[1]++;
            this.hs_Flag[1] = true;
            this.hs_Flag[3] = false;
            Debug.Log("check");
        }
        Debug.Log(prev_Axis5 = Input.GetAxis("Axis 5"));
        Debug.Log(prev_Axis6 = Input.GetAxis("Axis 6"));
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
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            this.pr_Buttons[1]++;
            //Debug.Log("check");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            this.pr_Buttons[2]++;
            //Debug.Log("check");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            this.pr_Buttons[3]++;
            //Debug.Log("check");
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

        switch(name)
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
        switch(name)
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
	// Use this for initialization
	void Start ()
    {
        //ボタンを押した回数を初期化
        for (int i = 0; i < 4; i++)
        {
            this.pr_Buttons[i] = 0;
            this.pl_Buttons[i] = 0;
            this.hs_Flag[i] = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
            
	}
}
