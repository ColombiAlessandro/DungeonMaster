using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Nemico : MonoBehaviour
{
    public Transform bersaglio;
    [SerializeField] float velocit‡N;
    public InseguimentoNemici ins;
    private void Start()
    {
        //reference dello script "InseguimentoNemici"
        ins =GetComponent<InseguimentoNemici>();
    }

    private void Update()
    {
        inseguimento();
    }
    public void inseguimento()
    {
        //vede se il valore di bersaglio che punta all'oggetto reale nella memoria non abbia valore(null),se ha valore allora il nemico si muove verso di me
       if (bersaglio!=null)
        {
            transform.position = Vector2.MoveTowards(transform.position, bersaglio.position, velocit‡N * 0.001f);
        }
    }
    

}
