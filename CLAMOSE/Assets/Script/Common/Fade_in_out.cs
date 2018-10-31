using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//フェードインとフェードアウトを出来るようにします。

public class Fade_in_out : MonoBehaviour {

    public enum Mode
    {
        FadeIn,
        FadeOut,
    }

    //時間関係
    private float        fadetimeCount;
    public float         fadetime;

    //フェードさせたい画像の情報元
    private Color           fadetargetColor;
    private float           initializeOpacity;
    private Image           fadetargetImage;
    private SpriteRenderer  fadetargetSprite;

    //フェードインとアウトの選択が出来るように
    public Mode mode;


    void Start ()
    {
        //問題を解決できるようにここでnullチェック
        if (this.fadetargetColor == null)
        {
            Debug.Log("画像元の色がありません");
        }
        if(this.fadetargetImage == null && this.fadetargetSprite == null)
        {
            Debug.Log("リソースがありません");
        }

        //初期状態のα値を取得しておく
        if(this.fadetargetImage)
        {
            this.fadetargetColor = GetComponent<Image>().color;
            this.initializeOpacity = this.fadetargetColor.a;
        }
        else if(this.fadetargetSprite)
        {
            this.fadetargetColor = GetComponent<SpriteRenderer>().color;
            this.initializeOpacity = this.fadetargetColor.a;
        }

        this.fadetimeCount = 0;
	}


	void Update ()
    {
        //フェード処理が終了
        if(!this.isPlayFadenow())
        {
            return;
        }
		switch(this.mode)
        {
            case Mode.FadeIn:
                this.PlayFadeIn();
                break;
            case Mode.FadeOut:
                this.PlayFadeOut();
                break;
            default:
                //予期せぬ自体がおきたらアプリケーションを終了させる
                Debug.Log("フェード処理でエラー");
                Application.Quit();
                break;
        }
	}

    //フェード中かどうかを判別します
    private bool isPlayFadenow()
    {
        return this.fadetimeCount <= this.fadetime;
    }

    //フェードインを行います
    private void PlayFadeIn()
    {
        this.fadetimeCount += Time.deltaTime;
        this.fadetargetColor.a = 255 - this.fadetimeCount / this.fadetime * this.initializeOpacity;   
        if(this.fadetargetImage)
        {
            Color nowColor = this.fadetargetImage.color;
            this.fadetargetImage.color = new Color(this.fadetargetColor.a, nowColor.r, nowColor.g, nowColor.b);
        }
        if(this.fadetargetSprite)
        {
            Color nowColor = this.fadetargetSprite.color;
            this.fadetargetSprite.color = new Color(this.fadetargetColor.a, nowColor.r, nowColor.g, nowColor.b);
        }
    }

    //フェードアウトを行います
    private void PlayFadeOut()
    {

    }



}
