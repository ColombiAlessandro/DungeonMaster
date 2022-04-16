using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private Nemico enemy;
    [SerializeField]public GameObject nemico;
    [SerializeField] float spawnTime;
    private float tempo;
    private int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        enemy = nemico.GetComponent<Nemico>();
      //  StartCoroutine("SpawnEnemy");

    }

    // Update is called once per frame
    void Update()
    {
        tempo = Time.time;
        Debug.Log(tempo);
       
          
    }
    /* private void Spawn()
     {
         while (i < 1)
         {
             Invoke("EnemySpawn", 5);
             i++;
         }
         i = 0;
     }*/
   
  /* IEnumerator SpawnEnemy()
    {
      while(i<3)
        {
            Instantiate(nemico, transform.position, Quaternion.identity);
            i++;
        }
        yield return new WaitForSeconds(3);
        
    }*/
}
