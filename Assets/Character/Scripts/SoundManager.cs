using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //UI Element accessing properties of UI elements via code
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void Save()
    {
    //PlayerPrefs - stores and access player preferences between game sessions
    PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
