using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFocusManagerTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var focusMgr = UGames.Game01.InputFocusManager.Instance;
        focusMgr.Register(this);
        Debug.Log("IFMT: 1A:" + focusMgr.GetCurrent());
        Debug.Log("IFMT: 1B" + (focusMgr.GetCurrent() == this));
        Debug.Log("IFMT: 1C:" + focusMgr.Count);
        var newBehaviour = new InputFocusManagerTest();
        focusMgr.Register(newBehaviour);
        Debug.Log("IFMT: 2A:" + focusMgr.GetCurrent());
        Debug.Log("IFMT: 2B" + (focusMgr.GetCurrent() == this));
        Debug.Log("IFMT: 2C:" + focusMgr.Count);
        focusMgr.Unregister(newBehaviour);
        Debug.Log("IFMT: 3A:" + focusMgr.GetCurrent());
        Debug.Log("IFMT: 3B" + (focusMgr.GetCurrent() == this));
        Debug.Log("IFMT: 3C:" + focusMgr.Count);
        var result5 = focusMgr.Unregister(this);
        Debug.Log("IFMT: 4A:" + focusMgr.GetCurrent());
        Debug.Log("IFMT: 4B" + (focusMgr.GetCurrent() == this));
        Debug.Log("IFMT: 4C:" + focusMgr.Count);
        Debug.Log("IFMT: 4D:" + result5);
        focusMgr.Unregister(null);
        Debug.Log("IFMT: 5A:" + focusMgr.GetCurrent());
        Debug.Log("IFMT: 5B" + (focusMgr.GetCurrent() == this));
        Debug.Log("IFMT: 5C:" + focusMgr.Count);
        focusMgr.Register(null);
        Debug.Log("IFMT: 6A:" + focusMgr.GetCurrent());
        Debug.Log("IFMT: 6B" + (focusMgr.GetCurrent() == this));
        Debug.Log("IFMT: 6C:" + focusMgr.Count);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
