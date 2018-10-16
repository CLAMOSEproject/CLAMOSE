using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject bfl, bfr, sfl, sfr;
    public GameObject Goal;
    public GameObject PL, PR;

	// Use this for initialization
	void Start ()
    {
        //0は右方向に進む
		if(Random.Range(0,1) == 0)
        {
            //各魚の場所に各プレイヤを移動させる
            PL.transform.position = bfr.transform.position;
            PR.transform.position = sfr.transform.position;
            //左プレイヤは大きい魚            
            PL.transform.SetParent(Instantiate(bfr).transform);
            //右プレイヤは小さい魚            
            PR.transform.SetParent(Instantiate(sfr).transform);
            //ゴール生成
            Vector3 goal_Pos = new Vector3(3500, 0, 0);
            Instantiate(Goal, goal_Pos, Quaternion.identity);
        }
        //左方向に進む
        else
        {
            //各魚の場所に各プレイヤを移動させる
            PL.transform.position = bfl.transform.position;
            PR.transform.position = sfl.transform.position;
            //左プレイヤは大きい魚            
            PL.transform.SetParent(Instantiate(bfl).transform);
            //右プレイヤは小さい魚            
            PR.transform.SetParent(Instantiate(sfl).transform);

            //ゴール生成
            Vector3 goal_Pos = new Vector3(-3500, 0, 0);
            Instantiate(Goal,goal_Pos,Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
