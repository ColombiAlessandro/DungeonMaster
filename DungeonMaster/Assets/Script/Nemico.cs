using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Nemico : MonoBehaviour
{
    [SerializeField] float velocit‡N;
    [SerializeField] GameObject giocatore;
    [SerializeField] public int vite;
    [SerializeField] GameObject pozione;
    public Player player;
    private int rilascioPozione;
    public Vector2 movimento;
    public Rigidbody2D rb;
    private Animator animazione;
    private void Start()
    {
        player = giocatore.GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        animazione = GetComponent<Animator>();
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
                PerditaVite();
            }
        }
    }
    public void PerditaVite()
    {
        vite--;
        if (vite == 0)
        {
            rilascioPozione = UnityEngine.Random.Range(0, 6);
            if (rilascioPozione == 1)
            {
                Instantiate(pozione, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    
}
