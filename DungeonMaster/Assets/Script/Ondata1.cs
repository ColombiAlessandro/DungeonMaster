using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ondata1 : MonoBehaviour
{
    private float SpawnMiniBossS = 5f, SpawnSlimeA = 3f;
    [SerializeField] GameObject[] nemici;
    [SerializeField] GameObject MiniBoss1,creaN;
    public bool EndSpawn = false;
    public int i = 0;
    private CreazioneNemici CN;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(nemici[2], SpawnSlimeA));
        CN = creaN.GetComponent<CreazioneNemici>();
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
             CN.anim.SetBool("Acceso", true);
             
        }
        if (i == 6)
        {
            yield return new WaitForSeconds(SpawnMiniBossS);
            MiniBoss1.SetActive(true);
            CN.anim.SetBool("Acceso", false);
        }
    }
}
