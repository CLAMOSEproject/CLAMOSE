using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_Alpha : MonoBehaviour
{
    public GameObject player;   
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GetComponent<F_Count_Down>().Get_Count()>=0)
        {
            Color bc = gameObject.GetComponent<Image>().color;

            bc.a = 0.0f;

            gameObject.GetComponent<Image>().color = bc;
            return;
        }

        //連打数を求める
        int mashed = 0;
        mashed += player.transform.parent.GetComponent<VATfunction>().Get_Masshed_Button_All("PL");
        mashed += player.transform.parent.GetComponent<VATfunction>().Get_Masshed_Button_All("PR");

        mashed *= 5;

        //だんだん透明度を下げる
        float alpha = 100 - mashed;

        Color c = gameObject.GetComponent<Image>().color;

        c.a = alpha/100.0f;

        gameObject.GetComponent<Image>().color = c;
    }
}
