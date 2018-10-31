using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movie_Selector : MonoBehaviour
{
    int now_Game;
    string[] games_Name;
	// Use this for initialization
	void Start ()
    {
        games_Name = new string[Game_Selector.max_Games]{ "ChargeMachine", "ColorMerge", "Fish_Run" };
        now_Game = Game_Selector.Next_Game();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SceneManager.LoadScene(games_Name[now_Game]);
	}
}
