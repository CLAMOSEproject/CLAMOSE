using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameJudge : MonoBehaviour
{

    public User playerLeft;
    public User playerRight;

    private User.WinorLos matchDecisionplayerLeft;
    private User.WinorLos matchDecisionplayerRight;

    // Use this for initialization
    void Start()
    {
        if (this.playerLeft == null || this.playerRight == null)
        {
            Debug.Log("Player設置してないよお");
            Application.Quit();
        }

        this.matchDecisionplayerLeft = this.playerLeft.getWinorLos();
        this.matchDecisionplayerRight = this.playerRight.getWinorLos();

    }

    // Update is called once per frame
    void Update()
    {
        if(this.isGamePlaynow())
        {
            return;
        }
    }


    public bool isGamePlaynow()
    {
        return this.matchDecisionplayerLeft == User.WinorLos.Non && this.matchDecisionplayerRight == User.WinorLos.Non;
    }

}
