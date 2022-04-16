using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Nemico : MonoBehaviour
{
    [SerializeField] float velocit‡N;
    [SerializeField] GameObject giocatore;
    [SerializeField] GameObject nemico;
    [SerializeField] public int vite;
    public Player player; 
    
    private void Start()
    {
        player = giocatore.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        inseguimento();
    }
    public void inseguimento()
    {
        if (giocatore != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, giocatore.transform.position, velocit‡N * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.attacco == true)
            {
                Perdita_vite();
            }
        }
    }
    public void Perdita_vite()
    {
        vite--;
        if (vite == 0)
        {
            Destroy(gameObject);
        }
    }
    

}
