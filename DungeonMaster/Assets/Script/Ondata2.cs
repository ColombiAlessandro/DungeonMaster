using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ondata2 : MonoBehaviour
{
    private float creazioneNemici, SpawnMiniBossS=5f, SpawnSlimeR = 3f;
    [SerializeField] GameObject[] nemici;
    [SerializeField] GameObject Ondata1,MiniBoss2;
    public Ondata1 ondata1;
    private bool EndSpawn = false; 
    // Start is called before the first frame update
    void Start()
    {
        ondata1 = Ondata1.GetComponent<Ondata1>();    
        StartCoroutine(SpawnEnemy(nemici[1], SpawnSlimeR));
    }

    private IEnumerator SpawnEnemy(GameObject enemy, float spawnTime)
    {
        if (ondata1.i == 10)
        {
            EndSpawn = true;
            ondata1.i++;
        }
        else if (EndSpawn == false || ondata1.i == 10)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemy, transform.position, Quaternion.identity);
            ondata1.i++;
            StartCoroutine(SpawnEnemy(enemy, spawnTime));
        }
        if (ondata1.i == 11)
        {
            yield return new WaitForSeconds(SpawnMiniBossS);
            MiniBoss2.SetActive(true);
            Instantiate(MiniBoss2, transform.position, Quaternion.identity);
        }
    }

}
