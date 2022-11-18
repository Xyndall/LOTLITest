using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    public Toggle _toggle;

    public bool _FullScreen = true;
    public bool Changed = false;


    private void OnEnable()
    {
        Changed = false;
        _toggle = GetComponent<Toggle>();
        _toggle.isOn = Screen.fullScreen;
    }

    public void Change(bool on)
    {
        Changed = true;
        _FullScreen = on;
    }


}
