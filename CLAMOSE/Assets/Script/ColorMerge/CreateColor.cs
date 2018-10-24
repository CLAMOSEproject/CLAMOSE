using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateColor : MonoBehaviour {

    public GameObject prefab;
    private CountDown countDown;
    bool oneFlag = false;
    public monitaData data;
    enum State
    {
        Non,
        Create
    }
    State state;
	// Use this for initialization
	void Start () {
        countDown = gameObject.GetComponent<CountDown>();
        state = State.Non;
	}
	
	// Update is called once per frame
	void Update () {
        switch(state)
        {
            case State.Non:
                if (countDown.GetCurrentTime() == 0)
                {
                    if (!oneFlag)
                    {
                        state = State.Create;
                        oneFlag = true;
                    }
                }
                break;
            case State.Create:
                if(countDown.GetCurrentTime() == -1)
                {
                   // GameObject obj = Instantiate(prefab, new Vector3(0, 2.5f, 0), Quaternion.identity);
                    //ここで、設定した色情報を取得する
                   // obj.GetComponent<colorSelect>().SetColorData(data.GetColorData());
                    state = State.Non;
                }
                break;
        }
	}

    public void ResetCreate()
    {
        oneFlag = false;
    }
}
