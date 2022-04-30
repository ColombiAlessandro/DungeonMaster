using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Nemico : MonoBehaviour
{
    [SerializeField] public float velocit‡N;
    [SerializeField] GameObject giocatore;
    [SerializeField] public int vite;
    [SerializeField] GameObject pozione;
    private GameObject[] nemici;
    public Player player;
    private int rilascioPozione;
    public Vector2 movimento;
    public Rigidbody2D rb;
    private Animator animazione;
    private BoxCollider2D hitbox;
    private void Start()
    {
        nemici = GameObject.FindGameObjectsWithTag("Nemico");
        player = giocatore.GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        animazione = GetComponent<Animator>();
        hitbox = GetComponent<BoxCollider2D>();
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
                transform.position = Vector2.MoveTowards(transform.position, collision.gameObject.transform.position, -0.20f);
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

