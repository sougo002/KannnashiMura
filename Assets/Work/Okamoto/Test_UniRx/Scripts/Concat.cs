//********************************************************************************
//
// Concat
//
// Autor	: Okamoto
// Date		: 2017/06/25
// Fix		: 2017/06/25
//
//********************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Concat : Cube {

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

		//最初の60Frameはこれ
		var first = this.UpdateAsObservable().Select(_ => new Vector3(0.0f, 0.5f, 0.0f));
		//60Frame以降はこれ
		var second = this.UpdateAsObservable().Select(_ => new Vector3(0.5f, 0.0f, 0.0f));

		first	//最初の60frame
			.Take(60)
		.Concat(second)
			.Subscribe(v => Move(v.x, v.y));
	}
}
