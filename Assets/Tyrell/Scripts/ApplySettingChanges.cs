using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySettingChanges : MonoBehaviour
{

    public QualitySetter Qsetter;
    public ResolutionSetter Rsettter;
    public FullscreenToggle FScreen;

    public void ApplyChanges()
    {
        QualitySettings.SetQualityLevel(Qsetter.Qvalue);
        Screen.fullScreenMode = FScreen._FullScreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
        Resolution res = Screen.resolutions[Rsettter.Rvalue];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

}
