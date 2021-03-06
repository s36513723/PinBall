﻿using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HinjiJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }
		
    // Update is called once per frame
    void Update()
    { 
        //タッチ操作に対応(追記)
		if (Input.touchCount > 0)
		{
			for (int i = 0; i < Input.touchCount; i++) 
			{
				Touch touch = Input.GetTouch (i);
				if (touch.phase == TouchPhase.Began) {
					if (Input.GetTouch(i).position.x < Screen.width / 2.0f ) {
						if (tag == "LeftFripperTag") {
							SetAngle(this.flickAngle);
						}
					}
					if (Input.GetTouch(i).position.x > Screen.width / 2.0f) {
						if (tag == "RightFripperTag") {
							SetAngle(this.flickAngle);
						}
					}
				}
			    if (touch.phase == TouchPhase.Ended) {
					if (tag == "LeftFripperTag") {
							SetAngle (this.defaultAngle);
					}
					if (tag == "RightFripperTag") {
							SetAngle (this.defaultAngle);
					}
				}
			}
        }
	    // 左矢印キーを押した時、左フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle(this.flickAngle);
		}

		// 右矢印キーを押した時、右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle(this.flickAngle);
		}

		// 矢印キーを離した時、フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
		// 矢印キーを離した時、フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
	}


	//フリッパーの傾きを設定
	public void SetAngle(float angle)
	{
			JointSpring jointSpr = this.myHingeJoint.spring;
			jointSpr.targetPosition = angle;
			this.myHingeJoint.spring = jointSpr;
	}

}
