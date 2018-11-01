using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneState : MonoBehaviour {

    //public
    public int nextSceneChangeCount;

    //private
    float sceneChangeCnt;

    // Use this for initialization
    void Start () {
        sceneChangeCnt = 0;
	}
	
	// Update is called once per frame
	void Update () {
        sceneChangeCnt += Time.deltaTime;
        if(sceneChangeCnt >= nextSceneChangeCount)
        {
            SceneManager.LoadSceneAsync("Movie");
        }
	}
}
