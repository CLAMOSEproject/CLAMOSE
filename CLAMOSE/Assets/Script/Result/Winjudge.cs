using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winjudge : MonoBehaviour {

    public GameObject winPrefab;
    public GameObject LosePrefab;
    public GameObject drawPrefab;

    public GameObject leftCanvas;
    public GameObject rightCanvas;
	// Use this for initialization
	void Start () {
		if(CommonData.GetWinState(CommonData.CommonState.Player1))
        {
            //左が負けで、右が勝ち
            GameObject winObj = Instantiate(winPrefab, transform.position, Quaternion.identity);    //左
            GameObject loseObj = Instantiate(LosePrefab, transform.position, Quaternion.identity);   //右
            winObj.transform.SetParent(leftCanvas.transform, false);
            loseObj.transform.SetParent(rightCanvas.transform, false);
        }
        else if(CommonData.GetWinState(CommonData.CommonState.Player2))
        {
            //左が勝ちで、右が負け
            Instantiate(LosePrefab, transform.position, Quaternion.identity);
            Instantiate(winPrefab, transform.position, Quaternion.identity);
        }
        else if(CommonData.GetWinState(CommonData.CommonState.Draw))
        {
            //どちらも、引き分けを出す
            Instantiate(drawPrefab, transform.position, Quaternion.identity);
            Instantiate(drawPrefab, transform.position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
