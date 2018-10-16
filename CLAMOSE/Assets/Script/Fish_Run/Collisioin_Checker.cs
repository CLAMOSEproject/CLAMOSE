using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//追われる側おみにアタッチする
public class Collisioin_Checker : MonoBehaviour
{
    //負けた時立つフラグ
    bool loose_Flag;
    //勝った時に立つフラグ
    bool win_Flag;
    //オブジェクトの加速度クラス
    VATfunction vat;
    //ゴール地点
    public GameObject Goal;
    //対戦相手(追う側)
    public GameObject Other_Player;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ゴールにたどり着いたら勝利フラグを立てる（今は未実装)
        if(collision.gameObject == Goal)
        {
            this.win_Flag = true;
        }
        //追う側と当たったらゲームオーバー
        this.loose_Flag = true;
    }

    public bool Is_Eated()
    {
        return this.loose_Flag;
    }

    public bool Is_Alived()
    {
        return this.win_Flag;
    }
	// Use this for initialization
	void Start ()
    {
        this.loose_Flag = false;
        this.win_Flag = false;
        vat = GetComponent<VATfunction>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(this.Is_Eated())
        {
            //Debug.Log("Eated!");
            //this.GetComponent<GameObject>().active = false;
            gameObject.SetActive(false);
        }
        else if(this.Is_Alived())
        {
            //Other_Player.SetActive(false);
            Debug.Log("small win");
        }

        //Debug.Log(vat.Get_Angle_X());
	}
}
