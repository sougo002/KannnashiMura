//********************************************************************************
//
// InputButton
//
// Autor	: Okamoto
// Date		: 2017/06/24
// Fix		: 2017/06/25
//
//********************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class InputButton : Cube {

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
	public Button p_OnlyFirst;
	public Button p_SkipFirst;
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

		//ボタン押された時
		p_OnlyFirst.onClick.AsObservable()
			.First()	//初回のみ
			.Subscribe(p_Button => Move(5.0f, 0.0f));	//移動する

		//ボタン押された時
		p_SkipFirst.onClick.AsObservable()
			.Skip(1)	//最初の１回はスキップ
			.Subscribe(p_Button => Move(-5.0f, 0.0f));   //移動する
	}
}
