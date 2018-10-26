using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ここでは、モニターの制御を行います
//主に、色の決定、指定したタイミングで色を出すことを行います
public class MonitaSysmtem : MonoBehaviour {

    enum State
    {
        Create,
        Judge,
        Result,
        End,
        Non
    }
    //private:
    Vector3 colorData;
    int playCnt = 0;
    State state;
    int stateCnt = 0;
    //public:
    public int designatePushNum = 3;
    public monitaData data;
    public CountDown startCount;    //スタートをカウントする
    public judgeColor referee;      //審判
    public GameObject prefab;
    public GameObject nextGameText;

    // Use this for initialization
    void Start()
    {
        state = State.Non;
    }

    // Update is called once per frame
    void Update()
    {
        State nowState = state;
        nowState = Think(nowState);
        DoSystem(state);
        Debug.Log(state);
        ++stateCnt;
        //状態の更新
        UpdateState(nowState);
    }

    //色の生成
    void CreateColor()
    {
        Color randColor;
        //色の決定
        randColor.r = Random.Range(designatePushNum, 10);
        randColor.g = Random.Range(designatePushNum, 10);
        randColor.b = Random.Range(designatePushNum, 10);
        //色をVectorにする
        colorData = new Vector3(randColor.r, randColor.g, randColor.b);
        //色の格納
        SetMonitaColor();
        //色オブジェクトの生成
        GameObject obj = Instantiate(prefab, new Vector3(0, 2.5f, 0), Quaternion.identity);
        //ここで、設定した色情報を取得する
        obj.GetComponent<colorSelect>().SetColorData(colorData);
    }

    //生成した色を渡す
    public Vector3 GetColorData()
    {
        return colorData;
    }

    //モニタのデータに格納
    void SetMonitaColor()
    {
        data.GetComponent<monitaData>().SetColorData(colorData);
    }


    ///////////////////////
    //状態用の関数

    //状態を遷移させます
    State Think(State nowState)
    {
        State nextState = nowState;
        switch (nowState)
        {
            case State.Non:
                if (startCount.GetCurrentTime() == -1)
                {
                    nextState = State.Create;
                }
                break;
            case State.Create:
                nextState = State.Judge;
                break;
            case State.Judge:
                if(referee.GetWinState() != judgeColor.WinState.Non)
                {
                    nextState = State.Result;
                    ++playCnt;
                }
                break;
            case State.Result:
                //プレイ回数3回なら終了
                if (playCnt >= 3)
                {
                    nextState = State.End;
                    break;
                }
                //勝敗判定
                if(stateCnt >= 180)
                {
                    nextState = State.Non;
                }
                break;
            case State.End:
                break;
        }
        return nextState;
    }
    //現在の状態の動作を行います
    void DoSystem(State nowState)
    {
        switch(nowState)
        {
            case State.Non:
                startCount.PlayCnt();
                referee.ResetState();
                break;
            case State.Create:
                CreateColor();
                startCount.StopCnt();
                break;
            case State.Judge:
                referee.StartJudge();
                break;
            case State.Result:
                //リザルトシーンの時間の処理
                startCount.ResetTime();
                GameObject[] objs = GameObject.FindGameObjectsWithTag("theme");
                foreach(GameObject obj in objs)
                {
                    Destroy(obj);
                }
                data.SetColorData(new Vector3(0, 0, 0));
                if(stateCnt == 60)
                {
                    GameObject obj = Instantiate(nextGameText, transform.position, Quaternion.identity);
                    obj.AddComponent<KillEntity>().SetLimitTime(1);
                }
                break;
            case State.End:
                //最終結果を判定
                break;
        }
    }
    //状態の更新
    void UpdateState(State nowState)
    {
        if(state == nowState) { return; }
        state = nowState;
        stateCnt = 0;
    }

    //プレイヤーたちに勝負を始めるか返す
    //true: 勝負Start　false:勝負しない
    public bool IsPlayerOn()
    {
        return state == State.Judge;
    }

    //プレイヤーの色を初期化するか
    public bool IsPlayerResetColor()
    {
        return state == State.Non;
    }

    //リザルトを行うかのチェック
    public bool IsResultOn()
    {
        return state == State.Result;
    }
}
