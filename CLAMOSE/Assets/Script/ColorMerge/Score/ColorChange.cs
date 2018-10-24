using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {


    Color color;
    float timeCnt = 1.0f;
    SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 1, 1);
        timeCnt = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        timeCnt += Time.deltaTime * 0.7f;
        //y(t) = A * sin(2 * PI * F * t + a)
        //A:ふり幅
        //F:周期
        //t:変化量
        //a:初期変化
        color.r = Mathf.Cos(2 * Mathf.PI * 3.0f * timeCnt / 9 + 0.0f);
        color.g = Mathf.Cos(2 * Mathf.PI * 3.0f * timeCnt / 9 + 2.0f);
        color.b = Mathf.Cos(2 * Mathf.PI * 3.0f * timeCnt / 9 + 4.0f);
       
        gameObject.GetComponent<SpriteRenderer>().color = new Color(
        color.r,color.g,color.b);
      
    }
}
