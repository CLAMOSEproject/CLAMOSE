using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    Color color;
    int timeCnt = 0;
    SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        timeCnt++;
        //y(t) = A * sin(2 * PI * F * t + a)
        //A:ふり幅
        //F:周期
        //t:変化量
        //a:初期変化
        color.r = 2.0f * Mathf.Cos(2.0f * Mathf.PI * 3.0f * timeCnt / 3.0f + 0.0f);
        color.g = 2.0f * Mathf.Cos(2.0f * Mathf.PI * 3.0f * timeCnt / 3.0f + 2.0f);
        color.b = 2.0f * Mathf.Cos(2.0f * Mathf.PI * 3.0f * timeCnt / 3.0f + 4.0f);
        //更新
        Debug.Log(color);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(
            color.r,color.g,color.b);
	}
}
