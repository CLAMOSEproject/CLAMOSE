using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public Text timerText;
    public float totalTime;
    int cntTime = -2;


	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
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
}
