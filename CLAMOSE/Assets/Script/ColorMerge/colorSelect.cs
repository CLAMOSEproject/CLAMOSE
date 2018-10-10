using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSelect : MonoBehaviour {


    Vector3 colorData;
    // Use this for initialization
    void Start () {
        Color rand = new Color(
            Random.value, Random.value , Random.value , 1.0f);
        //0.0 ～ 1.0fの間のランダム
        colorData = new Vector3((int)(rand.r * 10), (int)(rand.g * 10),(int)(rand.b * 10));
       
        gameObject.GetComponent<SpriteRenderer>().color = new Color(
           rand.r, rand.g, rand.b);
    }

    // Update is called once per frame
    void Update () {
    
	}

    public Vector3 GetColorData()
    {
        return colorData;
    }
}
