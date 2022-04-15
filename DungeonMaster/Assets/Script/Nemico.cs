using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Nemico : MonoBehaviour
{
    [SerializeField] float velocitÓN;
    [SerializeField] GameObject giocatore;
    
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        inseguimento();
    }
    public void inseguimento()
    {
        if (giocatore != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, giocatore.transform.position, velocitÓN * Time.deltaTime);
        }
    }
    

}
