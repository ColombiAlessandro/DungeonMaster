using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class Player : MonoBehaviour
{
    //dichiarazioni
    [SerializeField] float velocita;
    [SerializeField] int vite;
    public bool attacco;
    public Barra barra;
    private BoxCollider2D pg;
    public Rigidbody2D rb;
    private Animator animazione;
    public Vector2 movimento;
    private float cooldown = 0;
    private float durata;
    private float invulnerabilità=0;
    void Start()
    {
        //assegnazione variabili
        rb = GetComponent<Rigidbody2D>();
        pg = GetComponent<BoxCollider2D>();
        animazione = GetComponent<Animator>();
        barra.VitaMassima(vite);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= cooldown)
            {
                //cdAttacco.Reset();
                attacco = true;
                gameObject.tag.Replace("Player", "Attacco");
                animazione.SetBool("Attacco", true);
                //timerAttacco.Start();
                cooldown = Time.time + 1.0f;
                durata = Time.time + 0.5f;
            }
        }
        if (Time.time >= durata)
        {
            attacco = false;
            animazione.SetBool("Attacco", false);
            gameObject.tag.Replace("Attacco", "Player");
        }
    }
    private void FixedUpdate()
    {
        //movimento giocatore
        Movimento();
        //animazione movimento
        Animazione();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Nemico"))
        {
            if (attacco)
            {
                UnityEngine.Debug.Log("Colpito");
            }
            else
            {
                if (Time.time >= invulnerabilità)
                {
                    Danno();
                    invulnerabilità = Time.time + 1.0f;
                }
            }
        }
    }
    private void Movimento()
    {
        movimento.x = Input.GetAxis("Horizontal") * velocita;
        movimento.y = Input.GetAxis("Vertical") * velocita;
        rb.MovePosition(rb.position + movimento);
    }
    private void Animazione()
    {
        animazione.SetFloat("Orizzontale", movimento.x);
        animazione.SetFloat("Verticale", movimento.y);
        animazione.SetFloat("Velocità", movimento.sqrMagnitude);
        
    }
    private void Danno()
    {
        vite--;
        barra.ImpostaVita(vite);
        if (vite == 0)
        {
            Destroy(gameObject);
        }
    }
}
