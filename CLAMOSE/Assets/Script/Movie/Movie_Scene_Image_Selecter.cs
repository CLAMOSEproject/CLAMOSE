using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movie_Scene_Image_Selecter : MonoBehaviour
{
    //画像の配列
    public Sprite[] image;
    //選択用
    int index;

    //イメージセット
    public void Set_Image(int i)
    {
        index = i;

        GetComponent<Image>().sprite = image[i];
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
