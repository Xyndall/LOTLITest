using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueToText : MonoBehaviour
{
    public Slider sliderUI;
    public TextMeshProUGUI textSliderValue;


    private void Update()
    {
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        string sliderMessage = sliderUI.value.ToString("F1");
        textSliderValue.text = sliderMessage;
    }
}
