using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject Giocatore;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        player = Giocatore.GetComponent<Player>();
    }
    private void Update()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
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
