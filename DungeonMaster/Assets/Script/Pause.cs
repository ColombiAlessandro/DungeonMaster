using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool paused;
    public GameObject PauseMenu;
    [SerializeField] GameObject player;
    public Player pl;
    private void Start()
    {
        PauseMenu.SetActive(false);
        pl = player.GetComponent<Player>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }
        if (paused == true)
        {
            Pausa();
            pl.slash.Stop();
        }
        else
        {
            UnPause();
        }
    }
    public void Pausa()
    {
        
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void UnPause()
    {
        
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
