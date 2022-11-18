using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionSetter : MonoBehaviour
{
    public TMP_Dropdown _dropdown;
    public int Rvalue;
    public bool Changed = false;

    void Start()
    {
        

        Changed = false;
        _dropdown = GetComponent<TMP_Dropdown>();
        _dropdown.options.Clear();
        Resolution[] res = Screen.resolutions;
        int length = res.Length;
        for (int i = 0; i < length; i++)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData(res[i].ToString());
            _dropdown.options.Add(data);
            if (res[i].Equals(Screen.currentResolution))
                _dropdown.value = i;
        }

    }


    public void OnChange(int value)
    {
        Changed = true;
        Rvalue = value;
        
    }
}
