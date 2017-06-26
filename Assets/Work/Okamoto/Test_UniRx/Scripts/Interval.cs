//********************************************************************************
//
// Interval
//
// Autor	: Okamoto
// Date		: 2017/mm/dd
// Fix		: 2017/mm/dd
//
//********************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Interval : MonoBehaviour {

	//********************************************************************************
	//MACRO
	//********************************************************************************
	//CLASS BEFORE
	//********************************************************************************
	//STRUCTURE
	//********************************************************************************
	//CLASS AFTER
	//********************************************************************************
	//PUBLIC
	//********************************************************************************
	//PRIVATE
	//********************************************************************************

	//******************************
	//Start
	//起動後初回に実行される
	//******************************
	void Start ()
	{
		//初期座標
		Observable.Return(this.gameObject.transform.localPosition)
			.Subscribe(pos => this.gameObject.transform.localPosition = pos);

#if skip
		//0.5秒ごとに
		Observable.Interval(TimeSpan.FromMilliseconds(500))
			.Subscribe(_ => this.transform.localScale = this.transform.localScale * 1.05f)	//だんだん大きくなる
			.AddTo(this);	//missing回避
#endif
		//0.5秒ごとに(frame版)
		Observable.IntervalFrame(30)
			.Where(_ => this.transform.localScale.x <= 15.0f)
			.Subscribe(_ => this.transform.localScale = this.transform.localScale * 1.05f)  //だんだん大きくなる
			.AddTo(this);   //missing回避
	}
}
