using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemico2 : MonoBehaviour
{
    [SerializeField] float velocit‡N;
    [SerializeField] GameObject giocatore;
    [SerializeField] public int vite;
    public Player player;
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
        Animazione();

       
    }
    public void inseguimento()
    {
        if (giocatore != null)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, giocatore.transform.position, velocit‡N * Time.deltaTime));
            movimento = transform.position - giocatore.transform.position;
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
            Destroy(gameObject);
        }
    }
    private void Animazione()
    {
        animazione.SetFloat("X",movimento.x);
        animazione.SetFloat("Y",movimento.y);
    }
}
