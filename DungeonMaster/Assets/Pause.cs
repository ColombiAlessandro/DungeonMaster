using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool pausa;
    public GameObject PauseMenu;

    private void Start()
    {
        PauseMenu.SetActive(false);
        pausa = false;


    }

    private void Update()
    {
        UnityEngine.Debug.Log(Time.timeScale);
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pausa == true)
            {
                UnityEngine.Debug.Log("primattrue" + pausa);
                UnPause();
                UnityEngine.Debug.Log("dopotrue"+pausa);
            }
            else if(pausa==false)
            {
                UnityEngine.Debug.Log("primafalse" + pausa);
                Pausa();
                UnityEngine.Debug.Log("dopofalse" + pausa);
            }
        }
    }
    public void Pausa()
    {
        
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
        
    }
    public void UnPause()
    {
        
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pausa = false;
     
    }
}
