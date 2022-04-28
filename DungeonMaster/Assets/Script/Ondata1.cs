using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ondata1 : MonoBehaviour
{
    private float creazioneNemici, SpawnMiniBossS = 5f, SpawnSlimeV = 3.5f, SpawnSlimeA = 3f;
    [SerializeField] GameObject[] nemici;
    [SerializeField] GameObject MiniBoss1;
    public bool EndSpawn = false;
    public int i = 0,j=0;
    public Nemico SlimeR,SlimeV,SlimeA;
    // Start is called before the first frame update
    void Start()
    {
        SlimeR = nemici[1].GetComponent<Nemico>();
        SlimeV = nemici[0].GetComponent<Nemico>();
        SlimeA = nemici[2].GetComponent<Nemico>();
        StartCoroutine(SpawnEnemy(nemici[2], SpawnSlimeA));
    }
    private void Update()
    {
           
    }
    private IEnumerator SpawnEnemy(GameObject enemy,float spawnTime)
    {
        if (i == 5 )
        {
            EndSpawn = true;
            i++;
        }
        else if (EndSpawn == false || i==5)
        {
             yield return new WaitForSeconds(spawnTime);
             Instantiate(enemy, transform.position, Quaternion.identity);
             i++;
             StartCoroutine(SpawnEnemy(enemy, spawnTime));
             
        }
        if (i == 6)
        {
            yield return new WaitForSeconds(SpawnMiniBossS);
            MiniBoss1.SetActive(true);
            Instantiate(MiniBoss1, transform.position, Quaternion.identity);
        }
    }
}
