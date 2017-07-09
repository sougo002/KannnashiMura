using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UGames.Game01;

public class StringManagerTest : MonoBehaviour {

	// Use this for initialization
    void Start () {
        var sm = StringManager.Instance;
        
        // 普通の使い方
        Debug.Log(sm.GetString(StringID.MSG0010));
        Debug.Log(sm.GetString(StringID.NVL0010));
        Debug.Log(sm.GetString(StringID.BTN001));

        // 全部出してみる
        Debug.Log("------------------------------");
        foreach (var id in sm.GetIDList())
        {
            Debug.Log(sm.GetString(id));

        }
        try
        {
            Debug.Log(sm.GetString("aaaaaaa"));
        } catch (Exception e) {
            Debug.LogWarning(e.StackTrace);
        }
        try
        {
            Debug.Log(sm.GetString(null));
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.StackTrace);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
