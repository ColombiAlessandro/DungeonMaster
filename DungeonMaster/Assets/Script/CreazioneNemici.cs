using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreazioneNemici : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animazioni;
    [SerializeField] GameObject[] nemici;
    //tempo tra un'ondata di nemici e quella dopo
    private float creazioneNemici;
    private int temp;
    private float cooldownNascite;
    void Start()
    {
        temp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        CreazioneNemiciTOT();
       //Debug.Log(Time.time);
    }
    private void CreazioneNemiciTOT()
    {
        if (Time.time >= creazioneNemici)
        { 
            if (temp < 5)
            {
                for (int i = 0; i < temp; i++)
                {
                    if (Time.time >= cooldownNascite)
                    {
                        Instantiate(nemici[0], transform.position, Quaternion.identity);
                        cooldownNascite=Time.time+0.5f;
                    }
                    else i--;
                }
            }
            else if (temp < 7)
            {
                for (int i = 0; i < temp - 4; i++)
                {
                    if (Time.time >= cooldownNascite)
                    {
                        Instantiate(nemici[0], transform.position, Quaternion.identity);
                        Instantiate(nemici[1], transform.position, Quaternion.identity);
                        cooldownNascite = Time.time + 0.5f;
                    }
                    else i--;
                }
            }
            else if (temp < 10)
            {
                for (int i = 0; i < temp - 6; i++)
                {
                    if (Time.time >= cooldownNascite)
                    {
                        Instantiate(nemici[2], transform.position, Quaternion.identity);
                        Instantiate(nemici[1], transform.position, Quaternion.identity);
                        cooldownNascite = Time.time + 0.5f;
                    }
                    else i--;
                }
            } else if (temp == 10)
            {
                //boss
                temp = 1;
            }
            temp++;
            creazioneNemici = Time.time + 5;
        }
        
    }
}
