using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F_Count_Down : MonoBehaviour
{
    //カウント
    public int down_Count;

    //プレイヤたち
    public GameObject player_Left, player_Right;

    public int Get_Count()
    {
        return down_Count;
    }
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(down_Count ==0)
        {
            player_Left.transform.parent.GetComponent<VATfunction>().Start_the_Game();
            player_Right.transform.parent.GetComponent<VATfunction>().Start_the_Game();            
        }

        down_Count--;
        
	}
}
