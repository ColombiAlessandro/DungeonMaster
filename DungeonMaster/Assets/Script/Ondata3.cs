using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ondata3 : MonoBehaviour
{
    private float SpawnBossG=5f, SpawnSlimeV = 2f;
    [SerializeField] GameObject[] nemici;
    [SerializeField] GameObject Ondata1,Boss,WaveMusic,creaN;
    public Ondata1 ondata1;
    public Player player;
    private bool EndSpawn = false;
    private CreazioneNemici CN;
    // Start is called before the first frame update
    void Start()
    {
        ondata1 = Ondata1.GetComponent<Ondata1>();
        StartCoroutine(SpawnEnemy(nemici[0], SpawnSlimeV));
        CN = creaN.GetComponent<CreazioneNemici>();
    }
    private IEnumerator SpawnEnemy(GameObject enemy, float spawnTime)
    {
        if (ondata1.i == 15)
        {
            EndSpawn = true;
            ondata1.i++;
        }
        else if (EndSpawn == false || ondata1.i == 15)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemy, transform.position, Quaternion.identity);
            ondata1.i++;
            StartCoroutine(SpawnEnemy(enemy, spawnTime));
            CN.anim.SetBool("Acceso", true);
        }
        if (ondata1.i == 16)
        {
            yield return new WaitForSeconds(SpawnBossG);
            WaveMusic.SetActive(false);
            Boss.SetActive(true);
            CN.anim.SetBool("Acceso", false);
        }
    }
}
