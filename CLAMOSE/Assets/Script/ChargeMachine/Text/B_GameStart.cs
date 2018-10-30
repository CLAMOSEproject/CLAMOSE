using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_GameStart : MonoBehaviour
{
    //画像関連
    public Sprite[] gamestartFont;
    private Image gamestartText;

    //時間関連
    private float renderTime;
    private float renderTimeReplace;

    //現在操作している場所
    private enum Form
    {
        form1 = 0,
        form2 = 1,
        form3 = 2,
        form4 = 3,
        end = 4
    };

    Form form;

    // Use this for initialization
    void Start()
    {
        //画像関連
        this.gamestartText = GetComponent<Image>();

        //時間関連
        this.renderTime = 0;
        this.renderTimeReplace = 1.0f;

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
    void Update()
    {
        short nowrenderImage =  (short)this.form;

        //Startが表示された後はもう表示しない
        if (!this.isDrawing())
        {
            this.gamestartText.enabled = false;
            return;
        }

        //数値を切り替える
        if (this.isChengeimageTime())
        {
            nowrenderImage++;
            this.form = (Form)nowrenderImage;
            this.renderTime = 0;
        }
        else
        {
            this.AdditionUpdatetime();
            this.gamestartText.enabled = true;
        }

        this.gamestartText.sprite = this.gamestartFont[nowrenderImage];
    }


    //時間関連
    bool isChengeimageTime()
    {
        return this.renderTime >= this.renderTimeReplace;
    }

    //スタートが表示されているか？
    public bool isDrawing()
    {
        return (short)this.form < this.gamestartFont.Length - 1;
    }


    //このタイムでフォームを切り替える条件値を設定します
    void AdditionUpdatetime()
    {
        this.renderTime += Time.deltaTime;
    }
}
