﻿//********************************************************************************
//
// SkipWhile
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
using UniRx.Triggers;

public class SkipWhile : Cube {

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

		//左クリックされるまで待機
		this.UpdateAsObservable()
			.SkipWhile(_ => !Input.GetMouseButton(0))
			.Subscribe(_ => Move(0.1f, 0.0f));
	}
}
