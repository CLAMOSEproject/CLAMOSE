using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEntity : MonoBehaviour {

    public float limitTime;

    float cntTime;
	// Use this for initialization
	void Start () {
        cntTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        cntTime += Time.deltaTime;
        if(cntTime >= limitTime)
        {
            Destroy(this.gameObject);
        }
	}
    //消す時間をフレームで設定
    public void SetLimitTime(float limitTime)
    {
        this.limitTime = limitTime;
    }
}
