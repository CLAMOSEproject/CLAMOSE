using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColor : MonoBehaviour {

    Color color;
    Vector3 pushCount;
    public int playerNumber = 0;
	// Use this for initialization
	void Start () {
        color.r = 1.0f;
        color.b = 1.0f;
        color.g = 1.0f;   
    }
	
	// Update is called once per frame
	void Update () {
        switch(playerNumber)
        {
            case 1: Push(); break;
            case 2: Push2(); break;
        }

        //color.r = 1.0f - (pushCount.x / 10.0f);
        //color.g = 1.0f - (pushCount.y / 10.0f);
        //color.b = 1.0f - (pushCount.z / 10.0f);
        color.r = (pushCount.x / 10.0f);
        color.g =  (pushCount.y / 10.0f);
        color.b = (pushCount.z / 10.0f);

        Debug.Log(color);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(
          color.r, color.g, color.b);
    }

    void Push()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            pushCount.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            pushCount.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            pushCount.z += 1;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            pushCount.x = 0;
            pushCount.y = 0;
            pushCount.z = 0;
        }
    }

    void Push2()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            pushCount.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            pushCount.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            pushCount.z += 1;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            pushCount.x = 0;
            pushCount.y = 0;
            pushCount.z = 0;
        }
    }

    //プレイヤーが押したボタンの数(r,g,b)
    public Vector3 GetUserPushCount()
    {
        return pushCount;
    }
}
