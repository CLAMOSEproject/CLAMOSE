using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monitaData : MonoBehaviour {


    private Vector3 colorData;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetColorData(Vector3 colorData)
    {
        this.colorData = colorData;
    }
    public Vector3 GetColorData()
    {
        return this.colorData;
    }
}
