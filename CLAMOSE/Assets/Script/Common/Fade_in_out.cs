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
    private float         fadetimeCount;
    public  float         fadetime;

    //フェードさせたい画像の情報元
    private Color           fadetargetColor;
    private SpriteRenderer fadetargetSprite;
    private float           initializeOpacity;

    //フェードインとアウトの選択が出来るように
    public Mode mode;


    void Start ()
    {
        //問題を解決できるようにここでnullチェック
        if (this.fadetargetColor == null)
        {
            Debug.Log("画像元の色がありません");
        }

        //不透明度の代入
        this.fadetargetSprite = GetComponent<SpriteRenderer>();
        this.fadetargetColor = this.fadetargetSprite.color;
        this.initializeOpacity = this.fadetargetColor.a;

        this.fadetimeCount = 0;
	}


	void Update ()
    {
        //フェード処理ではない
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
    public void PlayFadeIn()
    {
        this.fadetimeCount += Time.deltaTime;
        //α値を代入
        float alfaaspect = 1 / this.fadetime;
        float alfaOpacity = this.initializeOpacity;

        alfaOpacity = 1 - (this.fadetimeCount * alfaaspect);
        Color nowcolor = this.fadetargetSprite.color;
        this.fadetargetSprite.color = new Color(alfaOpacity, nowcolor.r, nowcolor.g, nowcolor.b);
    }

    //フェードアウトを行います
    public void PlayFadeOut()
    {
        this.fadetimeCount += Time.deltaTime;
        //α値を代入
        float alfaaspect = 1 / this.fadetime;
        float alfaOpacity = this.initializeOpacity;

        alfaOpacity = this.fadetimeCount * alfaaspect;
        Color nowcolor = this.fadetargetSprite.color;
        this.fadetargetSprite.color = new Color(alfaOpacity, nowcolor.r, nowcolor.g, nowcolor.b);
    }

    //最初の状態に戻します
    public void ResetSpriteColor()
    {
        this.fadetimeCount = 0;
        Color resetColor = this.fadetargetColor;
        this.fadetargetSprite.color = new Color(this.initializeOpacity, resetColor.r,resetColor.g,resetColor.b);
    }
}
