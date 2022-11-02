using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer = null;
    public string ParamName;

    [SerializeField] private Slider _slider;

    void Start()
    {
        _slider.GetComponent<Slider>();
        float vol = PlayerPrefs.GetFloat(ParamName, 1);
        _slider.value = vol;
        SetVolume(vol);
    }

    public void SetVolume(float Value)
    {
        PlayerPrefs.SetFloat(ParamName, Value);
        Value *= 80;
        Value -= 80;


        audioMixer.SetFloat(ParamName, Value);
    }
}
