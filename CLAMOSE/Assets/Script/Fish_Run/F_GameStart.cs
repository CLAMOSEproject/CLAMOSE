using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F_GameStart : MonoBehaviour {

    public GameObject bfl, bfr, sfl, sfr;
    public GameObject Goal;
    public GameObject goal_Marker;
    public GameObject PL, PR;
    public GameObject canvas;

    int canvas_Width;
    int canvas_Height;

    // Use this for initialization
    void Start()
    {
        int x = Random.Range(0, 10);

        canvas_Width = (int)canvas.GetComponent<RectTransform>().rect.width;
        canvas_Height = (int)canvas.GetComponent<RectTransform>().rect.height;

        x %= 2;        
        //0は右方向に進む
        if (x == 0)
        {
            //各魚の場所に各プレイヤを移動させる
            PL.transform.position = bfr.transform.position;
            PR.transform.position = sfr.transform.position;
            //左プレイヤは大きい魚            
            PL.transform.SetParent(Instantiate(bfr).transform);
            //右プレイヤは小さい魚            
            PR.transform.SetParent(Instantiate(sfr).transform);
            //ゴール生成
            Vector3 goal_Pos = new Vector3(3800, 0, 60);
            //Instantiate(Goal, goal_Pos, Quaternion.identity);

            Goal.transform.position = goal_Pos;

            goal_Marker.transform.position = new Vector3(canvas_Width-20, canvas_Height-20, 0);
        }
        //左方向に進む
        else
        {
            //各魚の場所に各プレイヤを移動させる
            PL.transform.position = bfl.transform.position;
            PR.transform.position = sfl.transform.position;
            //左プレイヤは小さい魚  
            PL.transform.SetParent(Instantiate(sfl).transform);
            //右プレイヤは大きい魚            
            PR.transform.SetParent(Instantiate(bfl).transform);

            //ゴール生成
            Vector3 goal_Pos = new Vector3(-3800, 0, 60);
            //Instantiate(Goal,goal_Pos,Quaternion.identity);
            Goal.transform.position = goal_Pos;

            goal_Marker.transform.position = new Vector3(20, canvas_Height-20, 0);

            GetComponent<GameOverCheack>().Game_Going_Left();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
