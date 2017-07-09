using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モック用のプログラムなので、あとで作り直す。
/// </summary>
public class FlashLightSwitcher : MonoBehaviour
{
    [SerializeField]
    public Light myLight;

    // Use this for initialization
    void Start()
    {
        myLight = GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            //here you put the code of your event
            myLight.enabled = !myLight.enabled;
        }
    }
}
