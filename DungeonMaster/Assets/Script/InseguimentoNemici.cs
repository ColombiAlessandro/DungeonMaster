using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InseguimentoNemici : MonoBehaviour
{
    public Nemico nemico;
    

    private void Start()
    {
        nemico = GetComponentInParent<Nemico>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            nemico.bersaglio = collision.transform;
        }
    }

}
