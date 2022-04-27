using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }
    public void PulsanteRicomincia()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void PulsanteMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
