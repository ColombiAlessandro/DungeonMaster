using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public void VitaMassima(int vita)
    {
        slider.maxValue = vita;
        slider.value = vita;
    }
    public void ImpostaVita(int vita)
    {
        slider.value = vita;
    }
}
