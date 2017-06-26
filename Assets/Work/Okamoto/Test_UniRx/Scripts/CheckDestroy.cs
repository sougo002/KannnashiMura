//********************************************************************************
//
// CheckDestroy
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
using System;

public class CheckDestroy : Cube {

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

		//５秒後にオブジェクトがしぬ
		Observable.Timer(TimeSpan.FromSeconds(5))
			.Subscribe(_ => Destroy(this.gameObject));

		//0.5秒毎に移動
		Observable.Interval(TimeSpan.FromMilliseconds(500))
			.TakeUntilDestroy(this) //破棄されたら購読停止
			.Subscribe(_ => Move(1.0f, 0.0f));
			//.AddTo(this);	//破棄されたら購読停止
	}
}
