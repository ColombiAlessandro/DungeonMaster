using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMusic : MonoBehaviour
{
    public Slider Slider;
    public AudioSource grid;

    private void Start()
    {
      if(!PlayerPrefs.HasKey("grid"))
        {
            PlayerPrefs.SetFloat("grid", 1);
            Save();
        }
      else
        Load();
    }
    public void impostaSlider()
    {
        AudioListener.volume = Slider.value;
        Save();
    }
   private void Save()
    {
        PlayerPrefs.SetFloat("grid", Slider.value);
    }

   private void Load()
    {
        Slider.value=PlayerPrefs.GetFloat("grid");
    }
 
}
