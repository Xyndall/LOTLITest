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
        float vol = ES3.Load(ParamName, 0.5f);
        _slider.value = vol;
        SetVolume(vol);
    }

    public void SetVolume(float Value)
    {
        ES3.Save(ParamName, Value);
        Value *= 60;
        Value -= 60;


        audioMixer.SetFloat(ParamName, Value);
    }
}
