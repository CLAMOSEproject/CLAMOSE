using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

    //画像関連
    public Sprite[] gamestartFont;
    private Image  gamestartText;

    //時間関連
    private float  chengeimageTime;

    //現在操作している場所
    private enum Form
    {
        form1 = 0,
        form2 = 1,
        form3 = 2,
        form4 = 3,
        end   = 4
    };

    Form form;

	// Use this for initialization
	void Start ()
    {
        //画像関連
        this.gamestartText = GetComponent<Image>();

        //時間関連
        this.chengeimageTime = 0;

        //手順関連
        this.form = Form.form1;


        {
            bool nullflag = false;
            for (int i = 0; i < this.gamestartFont.Length; ++i)
            {
                if (this.gamestartFont[i] == null)
                {
                    nullflag = true;
                }
            }
            if (nullflag)
            {
                Debug.Log("リソースを設置してください");
            }
            else
            {
                this.gamestartText.sprite = null;
                this.gamestartText.enabled = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        int next = (int)this.form;
        
        if(next > (int)Form.end)
        {
            this.gamestartText.sprite = null;
            this.gamestartText.enabled = false;
            return;
        }
        //進行管理
        if (this.isChengeimageTime())
        {
            this.chengeimageTime = 0;
            next++;
            this.gamestartText.enabled = true;
            this.gamestartText.sprite = this.gamestartFont[(int)this.form];
        }
        else
        {
            this.chengeimageTime += Time.deltaTime;
        }
        this.form = (Form)next;
    }


    //時間関連
    bool isChengeimageTime()
    {
        return this.chengeimageTime >= 1.0f;
    }
}
