using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipale : MonoBehaviour
{
    
   public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
