using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class B_Result : MonoBehaviour
{
    //勝負判定を表示するのに必要な取得データ
    public Sprite[] resultText;

    //ゲームの結果表示に使用する
    private const int resultRenderTypes = 3;
    private SpriteRenderer resultRender;

    //表示時間関連
    private float timeMaxRenderresultText;
    private float timeCountRenderresultText;

    // Use this for initialization
    void Start()
    {
        this.resultRender = GetComponent<SpriteRenderer>();
        this.resultRender.enabled = false;
        //表示時間
        this.timeMaxRenderresultText = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToResult(User.WinorLos result)
    {
       //結果画面の表示時間が超えていない場合
       if(!this.isResultRenderTimeMax())
        {
            this.resultRender.enabled = true;
            this.timeCountRenderresultText += Time.deltaTime;

            if(result == User.WinorLos.Win)
            {
                this.resultRender.sprite = this.resultText[0];
            }
            else if(result == User.WinorLos.Los)
            {
                this.resultRender.sprite = this.resultText[1];
            }
       }
       else
       {
          //リザルトが終えたらもう表示しない
          this.resultRender.enabled = false;

            //次のゲームへ
            SceneManager.LoadScene("Result");
       } 
    }

    bool isResultRenderTimeMax()
    {
        return this.timeCountRenderresultText > this.timeMaxRenderresultText;
    }
}
