using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sattings : MonoBehaviour
{
    public Dropdown resolusionDropdown;
    public Dropdown qualityDropdown;
    public Slider soundVolium;
    
    Resolution[] resolutions;
   
    

    void Start()
    {
        soundVolium.value = PlayerPrefs.GetFloat("playerListenerSettings");
        resolusionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResalutionsIndex = 0; //число текущего разрешения экрана
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResalutionsIndex = i;
            }
        }
        
        resolusionDropdown.value = PlayerPrefs.GetInt("resolusionSetingsValue");
       
        resolusionDropdown.AddOptions(options);
        resolusionDropdown.RefreshShownValue();
        LoadSettings(currentResalutionsIndex);
    }

    private void Update()
    {
       
        
    }
    public void SetResolution(int resalutionsIndex)
    {
        Resolution resolution = resolutions[resalutionsIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
       
    }

    

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
      
    }   
    public void SoundValue(float soundVoliumFloat)
    {
        PlayerPrefs.SetFloat("playerListenerSettings", soundVoliumFloat);
        AudioListener.volume = soundVoliumFloat;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySetingsValue", qualityDropdown.value);
        PlayerPrefs.SetInt("resolusionSetingsValue", resolusionDropdown.value);
        
    }


    public void LoadSettings(int currentResalutionsIndex)
    {
        if (PlayerPrefs.HasKey("QualitySetingsValue"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySetingsValue");
        else
            qualityDropdown.value = 3;
        if (PlayerPrefs.HasKey("resolusionSetingsValue"))
            resolusionDropdown.value = PlayerPrefs.GetInt("resolusionSetingsValue");
        else
            resolusionDropdown.value = currentResalutionsIndex;
        /*if (PlayerPrefs.HasKey("FullScreen"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreen"));
        else
            Screen.fullScreen = true;*/
        /*if (PlayerPrefs.HasKey("SoundVolime"))
            AudioListener.volume = PlayerPrefs.GetFloat("SoundVolime");
        else
            AudioListener.volume = soundVolium.value;*/
    }
}


