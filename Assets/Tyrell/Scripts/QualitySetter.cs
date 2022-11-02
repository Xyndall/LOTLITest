using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QualitySetter : MonoBehaviour
{
    public TMP_Dropdown _dropdown;

    public int Qvalue;

    private void Start()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
        _dropdown.options.Clear();
        string[] qualityLevels = QualitySettings.names;

        for (int i = 0; i < qualityLevels.Length; i++)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData(qualityLevels[i]);
            _dropdown.options.Add(data);
        }

        _dropdown.value = QualitySettings.GetQualityLevel();

    }

    public void ChangeQuality(int value)
    {
        Qvalue = value;
    }
}
