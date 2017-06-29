﻿//********************************************************************************
//
// onCompleted
//
// Autor	: Okamoto
// Date		: 2017/06/24
// Fix		: 2017/06/25
//
//********************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class onCompleted : Cube {

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
	void Start()
	{
		//初期座標
		Observable.Return(this.gameObject.transform.localPosition)
			.Subscribe(pos => this.gameObject.transform.localPosition = pos);

		//移動
		this.UpdateAsObservable()
			.Take(120)  //120frame間
			.Subscribe(	_ => { Move(1.0f, 0.0f); },	//移動する
						() => { this.gameObject.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f); } );	//終わったらスケール小さくなる
	}
}