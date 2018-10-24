using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWinPoint : MonoBehaviour {
    //public
    public judgeColor referee;
    public GameObject prefab;
    public Transform[] scorePos = new Transform[3];
    public judgeColor.WinState winState;
    //private
    int scoreCnt;
    bool oneflag = false;

	// Use this for initialization
	void Start () {
        scoreCnt = 0;
	}
	
	// Update is called once per frame
	void Update ()
    { 
        if(referee.GetWinState() == winState)
        {
            OneEvent((int)winState - 1);
        }
        else
        {
            oneflag = false;
        }
	}

    void OneCnt(int number)
    {
        if(!oneflag)
        {
            ++scoreCnt;
            oneflag = true;
        }
    }
    void OneEvent(int number)
    {
        if (!oneflag)
        {
            Instantiate(prefab, scorePos[scoreCnt].position,Quaternion.identity);
            OneCnt(number);
        }
    }
}
