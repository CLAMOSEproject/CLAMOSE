using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movie_Selector : MonoBehaviour
{
    int now_Game;
    string[] games_Name;

    //各イメージ
    public GameObject round, setumei, tutorial, press;

    //制御用時間
    public int tick;
    //タイムカウント
    int time_Count;
    //破裂音
    public GameObject crash;

    // Use this for initialization
    void Start ()
    {
        games_Name = new string[Game_Selector.max_Games]{ "ChargeMachine", "ColorMerge", "Fish_Run" };
        now_Game = Game_Selector.Next_Game();

        //時間初期化
        time_Count = 0;

        //各イメージ初期化
        round.GetComponent<Movie_Scene_Image_Selecter>().Set_Image(Game_Selector.Get_Now_Round());
        tutorial.GetComponent<Movie_Scene_Image_Selecter>().Set_Image(now_Game);

        //全イメージをみえないようにする
        round.SetActive(false);
        setumei.SetActive(false);
        tutorial.SetActive(false);
        press.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //ラウンド説明表示処理
        switch(time_Count/tick)
        {
            case 1:
                round.SetActive(true);                
                setumei.SetActive(false);
                press.SetActive(false);
                if (time_Count % tick == 0)
                {
                    Instantiate(crash);
                }
                break;
            case 2:
                round.SetActive(false);
                setumei.SetActive(true);
                press.SetActive(false);
                if (time_Count % tick == 0)
                {
                    Instantiate(crash);
                }
                break;

            case 3:
                round.SetActive(false);
                setumei.SetActive(false);
                tutorial.SetActive(true);                
                press.SetActive(true);
                if (time_Count % tick == 0)
                {
                    Instantiate(crash);
                }
                break;
        }


        //ゲームをロード
        if (time_Count > 3600 || Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            SceneManager.LoadScene(games_Name[now_Game]);
        }

        //カウント上昇
        time_Count++;
	}
}
