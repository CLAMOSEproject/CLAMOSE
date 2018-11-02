using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject left_Player , right_Player;
    float root3 = 1.720634f;
	// Use this for initialization
	void Moving ()
    {
        //各プレイヤの位置をとってその中心にカメラが位置する
        Vector3 lp = left_Player.transform.parent.transform.position;
        Vector3 rp = right_Player.transform.parent.transform.position;
        Vector3 center;
        bool is_Going_Right = left_Player.transform.parent.GetComponent<VATfunction>().Get_Angle_X() > 0.0f;
        if (is_Going_Right)
        {
            //右方向のカメラ計算
            center = (rp - lp) / 2.0f;
        }
        else
        {
            //左方向カメラ計算
            center = (lp - rp) / 2.0f;
        }
       
        //Z位置を計算して適用
        float newz = center.magnitude;
       
        newz *= root3;
        if (is_Going_Right)
        {
            center += lp;
            center.x += 5;
        }
        else
        {
            center += rp;
            center.x -= 5;
        }
        center.z -= newz ;
        
        
        //位置更新
        this.transform.position = center;

        

    }
	
	// Update is called once per frame
	void Update ()
    {
        this.Moving();
	}
}
