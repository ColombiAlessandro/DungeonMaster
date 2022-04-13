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
    public static Stopwatch timerAttacco;
    public bool attacco;
    public Barra barra;
    private BoxCollider2D pg;
    public Rigidbody2D rb;
    private Animator animazione;
    public Vector2 movimento;
    
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
        
    }
    private void FixedUpdate()
    {
        
        
        
        if (Input.GetMouseButtonDown(0) && attacco==false)
        {
            attacco = true;
            animazione.SetBool("Attacco", true);
            timerAttacco.Start();
        }
        
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
                Danno();
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
