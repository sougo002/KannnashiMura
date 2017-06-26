//********************************************************************************
//
// Delay
//
// Autor	: Okamoto
// Date		: 2017/06/25
// Fix		: 2017/06/25
//
//********************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

public class Delay : Cube {

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
	public Button p_Button;
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

		//ボタンクリックされてから５秒後に移動
		p_Button.onClick.AsObservable()
			.Delay(TimeSpan.FromSeconds(5))
			.Subscribe(_ => Move(20.0f, 0.0f));
	}
}
