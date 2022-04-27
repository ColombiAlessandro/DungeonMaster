using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreazioneNemici : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animazioni;
    [SerializeField] GameObject[] nemici;
    //tempo tra un'ondata di nemici e quella dopo
    private float creazioneNemici,SpawnSlimeR=10f, SpawnSlimeV = 3.5f, SpawnSlimeA = 6f;
    private int temp,i=0,Ondata=1;
    private float cooldownNascite;
    private bool EndSpawn=false;
    IEnumerator Start()
    {

            StartCoroutine(EnemySpawn(nemici[0],SpawnSlimeV));
            StartCoroutine(EnemySpawn(nemici[1],SpawnSlimeR));          
            StartCoroutine(EnemySpawn(nemici[2],SpawnSlimeA));

        if ((i == 2 && Ondata==2)|| (i == 7 && Ondata == 3)|| (i == 12))
        {
            EndSpawn = false;
            i = 0;
            yield return new WaitForSeconds(10);
        }
             


        //StartCoroutine(EnemySpawn());
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
      /*  if (Time.time >= creazioneNemici)
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
        }*/
        
    }
    private IEnumerator EnemySpawn(GameObject Enemy,float TempoSpawn)
    {
        UnityEngine.Debug.Log("i:" + i);
        UnityEngine.Debug.Log(EndSpawn);
        if (i == 2)
        {
            EndSpawn = true;
            Ondata=2;
        }
        else if (i==7 && Ondata == 2)
        {
            EndSpawn = true;
            Ondata = 3;
        }
        else if (i == 12 && Ondata == 3)
        {
            EndSpawn = true;
        }



            if (EndSpawn == false)
        {
            yield return new WaitForSeconds(TempoSpawn);
            Instantiate(Enemy, transform.position, Quaternion.identity);
            StartCoroutine(EnemySpawn(Enemy, TempoSpawn));
        }
        i++;
        UnityEngine.Debug.Log("Ondata:" + Ondata);
        yield return new WaitForSeconds(10);
    }
   
}
