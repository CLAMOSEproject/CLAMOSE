using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Selector : MonoBehaviour
{
    /*
    ゲームのフラグ
    Charge_Machine = 1
    Color_Merge = 2
    Fish_Run = 3
    */

    static int[] remain_Games;
    public const int max_Games = 3;
    static int index;

    //テスト用カウンタ
    int time_Count;
	// Use this for initialization
	void Start ()
    {
        remain_Games = new int[max_Games]{0,0,0};

        //シャッフル
        //１回目
        int first_Game =Random.Range(0, 20);
        first_Game %= 3;
        remain_Games[0] = first_Game;

        //2回目
        int second_Game = 0;
        do
        {
            second_Game = Random.Range(0, 20);
            second_Game %= 3;
        } while (second_Game == first_Game);
        remain_Games[1] = second_Game;

        //３回目
        int third_Game = 3;
        third_Game -= (first_Game + second_Game);

        remain_Games[2] = third_Game;

        //ゲームインデックス初期化       
        index = -1;


        //テスト用
        time_Count = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(time_Count > 180)
        {
            SceneManager.LoadScene("Movie");
        }

        time_Count++;
	}

    public static int Next_Game()
    {
        //ムービーシーンでこれからやるゲームを選択するためのメソッド
        //インデックス上昇
        index++;
        //最大数を超えたらマイナス値を返す
        if(index >= max_Games)
        {
            return -1;
        }

        return remain_Games[index];
    }

    //今何ラウンドかを返す
    public static int Get_Now_Round()
    {
        return index;
    }
}
