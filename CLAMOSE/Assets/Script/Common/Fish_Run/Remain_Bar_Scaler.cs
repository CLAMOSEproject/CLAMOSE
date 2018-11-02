using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remain_Bar_Scaler : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        float canvas_Width = transform.parent.GetComponent<RectTransform>().rect.width;
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(canvas_Width, 70);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
