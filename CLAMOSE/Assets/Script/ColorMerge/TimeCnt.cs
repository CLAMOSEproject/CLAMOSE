using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCnt : MonoBehaviour {

    //private:
    float limitTime;
    float cnt;
    float plusCnt;
    bool resetFlag;
    bool isCntFlag;
	// Use this for initialization
	void Start () {
        cnt = 0.0f;
        limitTime = 60.0f;
        plusCnt = 1.0f;
        resetFlag = false;
        isCntFlag = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isCntFlag)
        {
            cnt += plusCnt;
        }
        if (IsLimit())
        {
            if (resetFlag)
            {
                ResetCount();
            }
        }
	}

    //カウントする値の設定
    public void SetPlusCount(float plusCount = 1.0f)
    {
        plusCnt = plusCount;
    }
    //カウントのリセット
    public void ResetCount()
    {
        cnt = 0.0f;
    }
    //制限時間の設定
    public void SetLimitTime(float limitTime)
    {
        this.limitTime = limitTime;
    }
    //制限時間になったか判定
    public bool IsLimit()
    {
        return cnt >= limitTime;
    }
    //制限時間になったら自動でリセットするかのフラグ
    public void SetResetCountFlag(bool resetFlag = true)
    {
        this.resetFlag = resetFlag;
    }
    //現在のフレームカウントを取得
    public float GetFrameCount()
    {
        return cnt;
    }
    //カウントを行うかを設定
    public void PlayCount(bool isPlay)
    {
        isCntFlag = isPlay;
    }
}
