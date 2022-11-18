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
        if (Qsetter.Changed)
        {
            QualitySettings.SetQualityLevel(Qsetter.Qvalue);
            ES3.Save("Quality", Qsetter.Qvalue);
            PlayerData.instance.QualitySet = Qsetter.Qvalue; 
            Debug.Log("Quality Changed");
        }

        if (FScreen.Changed)
        {
            
            Screen.fullScreenMode = FScreen._FullScreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
            ES3.Save("FullScreen", FScreen._FullScreen);
            PlayerData.instance.FullscreenSet = FScreen._FullScreen;
            Debug.Log("fullscreen Changed");
        }
        

        if (Rsettter.Changed)
        {
            Resolution res = Screen.resolutions[Rsettter.Rvalue];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen);
            ES3.Save("Resolution", Rsettter.Rvalue);
            PlayerData.instance.ResoulutionSet = Rsettter.Rvalue;
            Debug.Log("Resolution Changed");

        }
        
    }

}
