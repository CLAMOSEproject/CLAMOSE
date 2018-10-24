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
