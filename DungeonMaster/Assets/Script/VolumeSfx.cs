using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeSfx : MonoBehaviour
{
    public Slider Slider;
    public AudioSource player;
   /* void Start()
    {
        if (!PlayerPrefs.HasKey("player"))
        {
            PlayerPrefs.SetFloat("player", 1);
            Save();
        }
        else
            Load();
    }
    public void impostaSlider()
    {
        player.volume = Slider.value;
        Save();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("player", Slider.value);
    }

    private void Load()
    {
        Slider.value = PlayerPrefs.GetFloat("player");
    }*/

}
