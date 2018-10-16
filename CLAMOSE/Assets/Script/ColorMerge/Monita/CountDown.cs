using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public Text timerText;
    public float maxTime;
    int cntTime = -2;
    float totalTime;
    bool isCnt = false;

	// Use this for initialization
	void Start () {
        totalTime = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isCnt) { return; }

        totalTime -= Time.deltaTime;
        cntTime = (int)totalTime;
       
        if(cntTime == -2)
        {
            Destroy(this.gameObject);
        }
        string drawText;
        if(cntTime == 0)
        {
            drawText = "Start";
        }
        else if(cntTime <= -1)
        {
            drawText = "";
        }
        else
        {
            drawText = cntTime.ToString();
        }
        timerText.text = drawText;
	}

    //現在のカウントを取得する
    public int GetCurrentTime()
    {
        return cntTime;
    }

    //カウンターをリセットする
    public void ResetTime()
    {
        totalTime = maxTime;
    }

    //カウントを始めます
    public void PlayCnt()
    {
        isCnt = true;
    }
    //カウントを止めます
    public void StopCnt()
    {
        isCnt = false;
    }
}
